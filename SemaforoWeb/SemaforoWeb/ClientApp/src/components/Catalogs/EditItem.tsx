import React, {
  useState,
  useEffect,
  HTMLAttributes,
  forwardRef,
  Suspense,
} from 'react'
import PropTypes from 'prop-types'
import {
  CModal,
  CModalHeader,
  CModalBody,
  CButton,
  CModalFooter,
  CModalTitle,
  CForm,
  CRow,
  CFormLabel,
  CFormInput,
  CCol,
  CFormText,
  CFormSelect,
  CFormCheck,
  CFormTextarea,
  CDatePicker,
} from '@coreui/react-pro'

import {
  dataItem,
  dataColumn,
  fileDTO,
  dateField,
  singleImageFile,
} from '../../types'
import useFetch from '../Utils/useFetch'
import { useForm } from 'react-hook-form'
import { FileUploader } from './FileUploader'
import { SpinnerLoading } from '../Utils/spinnerLoading'

export interface EditItemProps extends HTMLAttributes<HTMLDivElement> {
  visible: boolean
  setVisible: (visible: boolean) => void
  itemData: dataItem
  itemIdField: string
  catalogFields: dataColumn[]
  onClose: () => void
  APIurl: string
  isNewItem: boolean
  itemHasBeenUpdated: (updated: boolean) => void
}

export const EditItem = forwardRef<HTMLDivElement, EditItemProps>(
  (
    {
      visible,
      setVisible,
      itemData,
      itemIdField,
      catalogFields,
      onClose,
      APIurl,
      isNewItem,
      itemHasBeenUpdated,
    },
    ref,
  ) => {
    const [formTitle, setFormTitle] = useState('')
    const [gallery, setGallery] = useState([])
    const [saveResponse, saveItem] = useFetch(APIurl, 'POST')
    const [isSaving, setIsSaving] = useState(false)
    const [existingFiles, setExistingFiles] = useState([] as File[])
    const [files, setFiles] = useState([] as File[])
    const [removedFilenames, setRemovedFilenames] = useState([] as string[])
    // const [existingImages, setExistingImages] = useState([] as File[]) // para el gallery

    const [singleImages, setSingleImages] = useState([] as singleImageFile[])
    const [dateValues, setDateValues] = useState([] as dateField[])
    const {
      register,
      handleSubmit,
      reset,
      formState: { errors },
    } = useForm<any>()

    type dataItemKey = keyof typeof itemData

    useEffect(() => {
      if (isNewItem) {
        setFormTitle('Agregando Nuevo Registro')
      } else {
        setFormTitle(
          'Editando Registro ' +
            itemData[itemIdField as dataItemKey] +
            ' - ' +
            itemData['name'],
        )
        if (itemData['files']) {
          // this is to convert files into valid bolb
          const convertFiles = async (dtoFiles: fileDTO[]) => {
            const convertedFiles = [] as File[]
            for (let i = 0; i < dtoFiles.length; i++) {
              const base64Response = await fetch(
                `data:${dtoFiles[i].contentType},${dtoFiles[i].archive}`,
              )
              const buf = await base64Response.arrayBuffer()
              const file = new File([buf], dtoFiles[i].fileName, {
                type: dtoFiles[i].contentType,
              })
              convertedFiles.push(file)
            }
            setExistingFiles([...existingFiles, ...convertedFiles])
          }
          convertFiles(itemData['files'])
        }

        const imageFields = catalogFields.filter((cf) => cf.type === 'image')
        const forLoopAsync = async () => {
          const existingImages = []
          for (let i = 0; i < imageFields.length; i++) {
            const imageString = itemData[imageFields[i].key as dataItemKey]
            if (imageString?.length > 0) {
              const sif: singleImageFile = {
                key: imageFields[i].key,
                file: await builtImage(
                  itemData[imageFields[i].key as dataItemKey],
                  imageFields[i],
                ),
              }
              existingImages.push(sif)
            }
          }
          setSingleImages(existingImages)
        }
        forLoopAsync()
      }
      reset(itemData)
    }, [itemData])

    useEffect(() => {
      if (!saveResponse) return
      setVisible(false)
      setIsSaving(false)
      itemHasBeenUpdated(true)
    }, [saveResponse])

    const builtImage = async (dtoImage: string, ifd: dataColumn) => {
      const base64Response = await fetch(`data:image/jpeg;base64,${dtoImage}`)
      const buf = await base64Response.arrayBuffer()
      const file = new File([buf], ifd.key + '.jpg', {
        type: 'image/jpeg',
      })
      return file
    }

    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }

    const handleFileChanges = ({
      key,
      image,
      action,
      removedFilename,
      newFiles,
    }: {
      key: string
      image?: File
      action: string
      removedFilename: string
      newFiles?: File[]
    }) => {
      switch (action) {
        case 'loadSingleImage':
          if (image) {
            const modifiedSingleImage: singleImageFile = { key, file: image }
            setSingleImages([...singleImages, modifiedSingleImage])
          }
          break
        case 'removeSingleImage':
          setSingleImages(singleImages.filter((si) => si.key !== key))
          break
        case 'updateRemovedFileList':
          if (
            itemData.files.find((f: fileDTO) => f.fileName === removedFilename)
          ) {
            setRemovedFilenames([...removedFilenames, removedFilename]) //remove from database
          } else {
            setFiles(files.filter((f) => f.name !== removedFilename)) // remove when just added not in db yet
          }
          break
        case 'loadNewFiles':
          if (newFiles) setFiles([...files, ...newFiles])
          break
        default:
          break
      }
    }

    const saveChanges = async (data: any) => {
      await setIsSaving(true)
      const formData = new FormData()
      if (singleImages.length > 0) {
        for (const sImg of singleImages) {
          formData.append('singleImages', sImg.file, sImg.key)
        }
      }
      if (gallery.length > 0) {
        for (const img of gallery) {
          formData.append('gallery', img)
        }
      }
      if (files.length > 0) {
        for (const file of files) {
          formData.append('files', file)
        }
      }
      if (removedFilenames.length > 0) {
        for (const name of removedFilenames) {
          formData.append('removedFiles', name)
        }
      }
      if (dateValues.length > 0) {
        for (let i = 0; i < dateValues.length; i++) {
          data[toLower(dateValues[i].field) as dataItemKey] =
            dateValues[i].datetime
        }
      }

      formData.append('dto', JSON.stringify({ ...data }))
      await saveItem(
        isNewItem ? '' : itemData[itemIdField as dataItemKey],
        formData,
        isNewItem ? 'POST' : 'PUT',
      )
      setFiles([])
      setRemovedFilenames([])
      setGallery([])
      setSingleImages([])
      setExistingFiles([])
    }

    const onCloseEdit = () => {
      setVisible(false)
      if (onClose) {
        setFiles([])
        setRemovedFilenames([])
        setGallery([])
        setSingleImages([])
        setExistingFiles([])
        onClose()
      }
    }

    const buildField = (f: dataColumn, itemData: dataItem, i: number) => {
      switch (f.type) {
        case 'select':
          return (
            <CFormSelect
              {...register(toLower(f.selectKey || f.key), {
                required: true,
              })}
              size="sm"
              aria-label={f.label}
              defaultValue={
                itemData[toLower(f.selectKey || '0') as dataItemKey]
              }
            >
              {Object.keys(itemData[toLower(f.key) as dataItemKey] || {}).map(
                (k) => (
                  <option key={k} value={k}>
                    {
                      (itemData[toLower(f.key) as dataItemKey] || '')[
                        k as never
                      ]
                    }
                  </option>
                ),
              )}
            </CFormSelect>
          )
        case 'boolean':
          return (
            <CFormCheck
              {...register(toLower(f.key))}
              id={'cb-' + f.key}
              defaultChecked={
                itemData[toLower(f.key) as dataItemKey] === 'true'
              }
            />
          )
        case 'textarea':
          return (
            <CFormTextarea
              {...register(toLower(f.key))}
              id={'textarea-' + f.key}
              rows={f.rows}
            />
          )
        case 'datetime':
          const dateUtcString = itemData[toLower(f.key) as dataItemKey]
          const dateUTC = dateUtcString ? new Date(dateUtcString + 'Z') : null
          return (
            <>
              <CDatePicker
                {...register(toLower(f.key))}
                id={'datetime-' + f.key}
                onDateChange={(utcDate) => {
                  const existing = dateValues.find((ex) => ex.field === f.key)
                  if (existing) {
                    existing.datetime = utcDate
                  } else {
                    const newDate: dateField = {
                      field: f.key,
                      datetime: utcDate,
                    }
                    setDateValues([...dateValues, newDate])
                  }
                }}
                date={dateUTC}
                timepicker
              />
            </>
          )
        case 'image':
          return (
            <FileUploader
              itemData={itemData}
              f={f}
              register={register}
              initialFiles={singleImages
                .filter((ei) => ei.key === f.key)
                .map((ei) => ei.file)}
              APIurl={APIurl}
              itemIdField={itemIdField}
              className={'sigle-image'}
              handleFileChanges={handleFileChanges}
            />
          )
        case 'gallery':
        case 'files':
          return (
            <Suspense fallback={<SpinnerLoading />}>
              <FileUploader
                itemData={itemData}
                f={f}
                register={register}
                initialFiles={existingFiles}
                className={'all-type-files'}
                APIurl={APIurl}
                itemIdField={itemIdField}
                rows={f.rows}
                handleFileChanges={handleFileChanges}
              />
            </Suspense>
          )
        default:
          return (
            <CFormInput
              {...register(toLower(f.key), {
                required: f.required || false,
                pattern: new RegExp(f.validationPattern || ''),
              })}
              id={'input-' + f.key}
              size="sm"
              defaultValue={itemData[toLower(f.key) as dataItemKey]}
              placeholder={f.label}
            />
          )
      }
    }

    return (
      <CModal
        size="xl"
        alignment="center"
        visible={visible}
        onClose={onCloseEdit}
      >
        {isSaving && <SpinnerLoading />}
        <CModalHeader>
          <CModalTitle>{formTitle}</CModalTitle>
        </CModalHeader>
        <CForm onSubmit={handleSubmit(saveChanges)}>
          <CModalBody>
            <CRow className="mb-2">
              {catalogFields
                .filter((c) => !c.isPrimaryKey)
                .map((f, i) => (
                  <CCol key={'field_' + i} sm={f.size || 12} className="mb-2">
                    <CFormLabel
                      htmlFor={'input-' + toLower(f.key)}
                      className="col-form-label"
                    >
                      {f.label}
                    </CFormLabel>
                    {f && itemData && buildField(f, itemData, i)}
                    {errors[toLower(f.key) as dataItemKey] && (
                      <CFormText component="span">
                        {errors[toLower(f.key) as dataItemKey]?.type ===
                          'required' && 'este campo es obligatorio'}
                        {errors[toLower(f.key) as dataItemKey]?.type ===
                          'pattern' && 'formato no valido'}
                      </CFormText>
                    )}
                  </CCol>
                ))}
            </CRow>
          </CModalBody>
          <CModalFooter>
            <CButton color="secondary" onClick={() => setVisible(false)}>
              Close
            </CButton>
            <CButton color="primary" type="submit">
              Guardar Cambios
            </CButton>
          </CModalFooter>
        </CForm>
      </CModal>
    )
  },
)

EditItem.propTypes = {
  visible: PropTypes.bool.isRequired,
  setVisible: PropTypes.func.isRequired,
  itemData: PropTypes.any.isRequired,
  itemIdField: PropTypes.string.isRequired,
  catalogFields: PropTypes.any.isRequired,
  onClose: PropTypes.func.isRequired,
  APIurl: PropTypes.string.isRequired,
  isNewItem: PropTypes.bool.isRequired,
  itemHasBeenUpdated: PropTypes.func.isRequired,
}

EditItem.displayName = 'EditItem'

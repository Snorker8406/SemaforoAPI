import React, { useState, useEffect, HTMLAttributes, forwardRef } from 'react'
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
} from '@coreui/react-pro'

import { dataItem, dataColumn } from '../../types'
import useFetch from '../Utils/useFetch'
import { useForm } from 'react-hook-form'

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
    const [saveResponse, saveItem] = useFetch(APIurl, 'POST')
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
      }
      reset(itemData)
    }, [itemData])

    useEffect(() => {
      if (!saveResponse) return
      setVisible(false)
      itemHasBeenUpdated(true)
    }, [saveResponse])

    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }

    const saveChanges = (formData: any) => {
      formData[itemIdField as dataItemKey] =
        itemData[itemIdField as dataItemKey]
      saveItem(
        isNewItem ? '' : itemData[itemIdField as dataItemKey],
        formData,
        isNewItem ? 'POST' : 'PUT',
      )
    }

    const onCloseEdit = () => {
      setVisible(false)
      if (onClose) {
        onClose()
      }
    }

    return (
      <CModal
        size="xl"
        alignment="center"
        visible={visible}
        onClose={onCloseEdit}
      >
        <CModalHeader>
          <CModalTitle>{formTitle}</CModalTitle>
        </CModalHeader>
        <CForm onSubmit={handleSubmit(saveChanges)}>
          <CModalBody>
            {catalogFields
              .filter((c) => !c.isPrimaryKey)
              .map((f, i) => (
                // eslint-disable-next-line react/jsx-key
                <CRow key={'field_' + i} className="mb-3">
                  <CFormLabel
                    htmlFor={'input-' + toLower(f.name)}
                    className="col-sm-2 col-form-label"
                  >
                    {f.columnName}
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormInput
                      {...register(toLower(f.name), { required: true })}
                      id={'input-' + f.name}
                      defaultValue={itemData[toLower(f.name) as dataItemKey]}
                    />
                    {errors[toLower(f.name) as dataItemKey] && (
                      <span>This field is required</span>
                    )}
                  </CCol>
                </CRow>
              ))}
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

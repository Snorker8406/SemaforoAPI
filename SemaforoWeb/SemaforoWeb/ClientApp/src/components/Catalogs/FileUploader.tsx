import React, {
  forwardRef,
  HTMLAttributes,
  Suspense,
  useContext,
  useState,
} from 'react'
import PropTypes, { any } from 'prop-types'
import { dataColumn, dataItem, fileDTO } from '../../types'
import 'react-dropzone-uploader/dist/styles.css'
import Dropzone from 'react-dropzone-uploader'
import { useEffect } from 'react'
import CIcon from '@coreui/icons-react'
import * as icon from '@coreui/icons'
import { SpinnerLoading } from '../Utils/spinnerLoading'
import { LoaderContext } from '../shared/loaderContext'

export interface FileUploaderProps extends HTMLAttributes<HTMLDivElement> {
  itemData: dataItem
  f: dataColumn
  register: any
  onChangeStatus: any
  existingFiles: File[]
  className?: string
  APIurl: string
  itemIdField: string
  rows?: number
}

export const FileUploader = forwardRef<HTMLDivElement, FileUploaderProps>(
  (
    {
      itemData,
      f,
      register,
      onChangeStatus,
      existingFiles,
      className,
      APIurl,
      itemIdField,
      rows,
    },
    ref,
  ) => {
    const [initialFiles, setInitialFiles] = useState([] as File[])
    const { setShowLoader } = useContext(LoaderContext)

    // useEffect(() => {
    //   setInitialFiles([...initialFiles, ...existingFiles])
    // }, [existingFiles])

    useEffect(() => {
      setInitialFiles([...existingFiles])
    }, [existingFiles])

    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }
    const handleChangeStatus = ({ meta, file }: never, status: string) => {
      onChangeStatus({ meta, file }, status, f.type, f.key)
    }

    const getFileInfo = (fileName: string) => {
      if (!itemData.files) return null
      const fileInfo = itemData.files.find(
        (f: fileDTO) => f.fileName === fileName,
      )
      return fileInfo
    }

    const downloadFile = (fileName: string) => {
      setShowLoader(true)
      const fileInfo = getFileInfo(fileName)
      const entityId = fileInfo[itemIdField]
      const fileId = fileInfo.fileId
      fetch(APIurl + entityId + '/DownloadFile/' + fileId)
        .then((res) => res.blob())
        .then((blob) => {
          const a = document.createElement('a')
          document.body.appendChild(a)
          a.style.display = 'none'
          const url = window.URL.createObjectURL(blob)
          a.href = url
          a.download = fileName
          a.click()
          window.URL.revokeObjectURL(url)
          setShowLoader(false)
        })
    }

    const fileIcon = (fileType: string) => {
      switch (fileType) {
        case 'application/vnd.openxmlformats-officedocument.wordprocessingml.document':
          return icon.cilTextSquare
        case 'application/pdf':
          return icon.cibAdobeAcrobatReader
        case 'image/png':
          return icon.cilImage
        default:
          return icon.cilFile
      }
    }
    const previewImage = (props: any) => {
      const {
        className,
        imageClassName,
        style,
        imageStyle,
        fileWithMeta: { cancel, remove, restart },
        meta: {
          name = '',
          percent = 0,
          size = 0,
          previewUrl,
          status,
          duration,
          validationError,
          type,
        },
        isUpload,
        canCancel,
        canRemove,
        canRestart,
        extra: { minSizeBytes },
      } = props
      const title = `${name || '?'}, ${size}`
      return (
        <div>
          {previewUrl && (
            <img
              className={imageClassName}
              style={imageStyle}
              src={previewUrl}
              alt={title}
              title={title}
            />
          )}
          {status !== 'preparing' &&
            status !== 'getting_upload_params' &&
            status !== 'uploading' &&
            canRemove && (
              <CIcon
                className="remove-file"
                onClick={remove}
                icon={icon.cilTrash}
                size="lg"
              />
            )}
        </div>
      )
    }

    const previewFiles = (props: any) => {
      const {
        className,
        imageClassName,
        style,
        imageStyle,
        fileWithMeta: { cancel, remove, restart },
        meta: {
          name = '',
          percent = 0,
          size = 0,
          previewUrl,
          status,
          duration,
          validationError,
          type,
        },
        isUpload,
        canCancel,
        canRemove,
        canRestart,
        extra: { minSizeBytes },
      } = props
      return (
        <div className="file-row-container container">
          <div className="file-row row pb-2 pt-2">
            <div className="col-md-1">
              <CIcon
                className="file-icon-type"
                onClick={() => downloadFile(name)}
                icon={fileIcon(type)}
                size="xl"
              />
            </div>
            <div className="col-md-9">
              <span>{name}</span>
            </div>
            <div className="col-md-1">
              <CIcon
                className={getFileInfo(name) ? 'download-icon' : 'add-icon'}
                onClick={() => downloadFile(name)}
                icon={getFileInfo(name) ? icon.cilCloudDownload : icon.cilPlus}
                color="success"
                size="lg"
              />
            </div>
            {canRemove && (
              <div className="col-md-1">
                <CIcon
                  className="remove-file"
                  onClick={remove}
                  icon={icon.cilTrash}
                  size="lg"
                />
              </div>
            )}
          </div>
        </div>
      )
    }

    const renderImageUploader = () => {
      return (
        <Dropzone
          key={'file-' + f.key}
          onChangeStatus={handleChangeStatus}
          styles={{
            previewImage: {
              height: f.rows ? f.rows * 24 + 14 + 'px' : '100px',
            },
            dropzoneReject: { borderColor: 'red', backgroundColor: '#DAA' },
            inputLabel: (files, extra) =>
              extra.reject ? { color: 'red' } : {},
          }}
          accept="image/*"
          inputContent={(files, extra) =>
            extra.reject ? 'Solo archivos de Imagen' : f.label
          }
          maxFiles={1}
          initialFiles={initialFiles}
          PreviewComponent={previewImage}
          addClassNames={{
            dropzone: className,
          }}
        />
      )
    }

    const renderImagesUploader = () => {
      return (
        <Dropzone
          {...register(toLower(f.key))}
          key={'file-' + f.key}
          onChangeStatus={handleChangeStatus}
          styles={{
            dropzone: { minHeight: 100, maxHeight: 400 },
            dropzoneReject: { borderColor: 'red', backgroundColor: '#DAA' },
            inputLabel: (files, extra) =>
              extra.reject ? { color: 'red' } : {},
          }}
          accept="image/*"
          inputContent={(files, extra) =>
            extra.reject ? 'Solo archivos de Imagen' : f.label
          }
          initialFiles={initialFiles}
        />
      )
    }
    const renderFilesUploader = () => {
      return (
        <Suspense fallback={<SpinnerLoading />}>
          <Dropzone
            {...register(toLower(f.key))}
            key={'file-' + f.key}
            onChangeStatus={handleChangeStatus}
            styles={{
              dropzone: { minHeight: 100, maxHeight: 400 },
              dropzoneReject: { borderColor: 'red', backgroundColor: '#DAA' },
              inputLabel: (files, extra) =>
                extra.reject ? { color: 'red' } : {},
            }}
            inputContent={(files, extra) =>
              extra.reject ? 'Archivo Invalido' : f.label
            }
            initialFiles={initialFiles}
            PreviewComponent={previewFiles}
            addClassNames={{
              dropzone: className,
            }}
          />
          {/* <SpinnerLoading
            color="primary"
            visible={isDownloading}
            type="loading"
            setVisible={setIsDownloading}
          /> */}
        </Suspense>
      )
    }
    switch (f.type) {
      case 'image':
        return renderImageUploader()
      case 'images':
        return renderImagesUploader()
      default:
        return renderFilesUploader()
    }
  },
)

FileUploader.propTypes = {
  itemData: PropTypes.any.isRequired,
  f: PropTypes.any.isRequired,
  register: PropTypes.func.isRequired,
  onChangeStatus: PropTypes.func.isRequired,
  className: PropTypes.string,
  APIurl: PropTypes.string.isRequired,
  itemIdField: PropTypes.string.isRequired,
  rows: PropTypes.number,
}

FileUploader.displayName = 'FileUploader'

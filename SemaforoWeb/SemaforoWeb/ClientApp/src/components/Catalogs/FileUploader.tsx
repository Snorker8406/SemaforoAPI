import React, { forwardRef, HTMLAttributes, useState } from 'react'
import PropTypes, { any } from 'prop-types'
import { dataColumn, dataItem, fileDTO } from '../../types'
import 'react-dropzone-uploader/dist/styles.css'
import Dropzone from 'react-dropzone-uploader'
import { useEffect } from 'react'
import CIcon from '@coreui/icons-react'
import * as icon from '@coreui/icons'
import useFetch from '../Utils/useFetch'

export interface FileUploadProps extends HTMLAttributes<HTMLDivElement> {
  itemData: dataItem
  f: dataColumn
  register: any
  onChangeStatus: any
  existingFiles: File[]
  className?: string
  APIurl: string
  itemIdField: string
}

export const FileUpload = forwardRef<HTMLDivElement, FileUploadProps>(
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
    },
    ref,
  ) => {
    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }

    const [initialFiles, setInitialFiles] = useState([] as File[])

    useEffect(() => {
      setInitialFiles([...initialFiles, ...existingFiles])
    }, [existingFiles])

    const handleChangeStatus = ({ meta, file }: never, status: string) => {
      onChangeStatus({ meta, file }, status, f.type, f.key)
    }

    const downloadFile = (fileName: string) => {
      const fileInfo = itemData.files.find(
        (f: fileDTO) => f.fileName === fileName,
      )
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
                onClick={() => downloadFile(name)}
                icon={icon.cilCloudDownload}
                color="success"
                size="lg"
              />
            </div>
            {canRemove && (
              <div className="col-md-1">
                <CIcon onClick={remove} icon={icon.cilTrash} size="lg" />
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
            dropzone: { minHeight: 111, maxHeight: 400 },
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
            dropzone: { minHeight: 111, maxHeight: 400 },
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
        <Dropzone
          {...register(toLower(f.key))}
          key={'file-' + f.key}
          onChangeStatus={handleChangeStatus}
          styles={{
            dropzone: { minHeight: 111, maxHeight: 400 },
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

FileUpload.propTypes = {
  itemData: PropTypes.any.isRequired,
  f: PropTypes.any.isRequired,
  register: PropTypes.func.isRequired,
  onChangeStatus: PropTypes.func.isRequired,
  className: PropTypes.string,
  APIurl: PropTypes.string.isRequired,
  itemIdField: PropTypes.string.isRequired,
}

FileUpload.displayName = 'FileUpload'

import React, { forwardRef, HTMLAttributes, useState } from 'react'
import PropTypes, { any } from 'prop-types'
import { dataColumn, dataItem } from '../../types'
import 'react-dropzone-uploader/dist/styles.css'
import Dropzone from 'react-dropzone-uploader'
import { useEffect } from 'react'

export interface FileUploadProps extends HTMLAttributes<HTMLDivElement> {
  itemData: dataItem
  f: dataColumn
  register: any
  onChangeStatus: any
  existingFiles: File[]
}

export const FileUpload = forwardRef<HTMLDivElement, FileUploadProps>(
  ({ itemData, f, register, onChangeStatus, existingFiles }, ref) => {
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
}

FileUpload.displayName = 'FileUpload'

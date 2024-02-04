import React, {
  forwardRef,
  HTMLAttributes,
  Suspense,
  useContext,
  useState,
} from 'react'
import PropTypes, { any } from 'prop-types'
import { dataColumn, dataItem, fileDTO, singleImageFile } from '../../types'
import 'react-dropzone-uploader/dist/styles.css'
import Dropzone from 'react-dropzone-uploader'
import CIcon from '@coreui/icons-react'
import * as icon from '@coreui/icons'
import { SpinnerLoading } from '../Utils/spinnerLoading'
import { LoaderContext } from '../shared/loaderContext'

export interface FileUploaderProps extends HTMLAttributes<HTMLDivElement> {
  itemData: dataItem
  f: dataColumn
  register: any
  initialFiles: File[]
  className?: string
  APIurl: string
  itemIdField: string
  rows?: number
  handleFileChanges: any
}

export const FileUploader = forwardRef<HTMLDivElement, FileUploaderProps>(
  (
    {
      itemData,
      f,
      register,
      initialFiles,
      className,
      APIurl,
      itemIdField,
      rows,
      handleFileChanges,
    },
    ref,
  ) => {
    const [singleImage, setSingleImage] = useState({} as singleImageFile)
    const { setShowLoader } = useContext(LoaderContext)
    let files: File[] = []
    let filesToLoadCount = 0

    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }
    const handleChangeStatus = ({ meta, file }: never, status: string) => {
      if (status === 'preparing') {
        filesToLoadCount++
      }
      if (status === 'done') {
        filesToLoadCount--
        switch (f.type) {
          case 'files':
            if (
              itemData['files'] &&
              itemData['files'].find(
                (f: never) => f['fileName'] === file['name'],
              )
            )
              break
            files.push(file)
            if (filesToLoadCount === 0) {
              handleFileChanges({
                key: f.key,
                newFiles: files,
                action: 'loadNewFiles',
              })
              files = []
            }
            break
          case 'gallery':
            if (
              itemData['gallery'] &&
              itemData['gallery']?.find(
                (f: never) => f['fileName'] === file['name'],
              )
            )
              break
            // setGallery([...gallery, file])
            break
          case 'image':
            handleFileChanges({
              key: f.key,
              image: file,
              action: 'loadSingleImage',
            })
            break
          default:
            break
        }
      }

      if (status === 'removed') {
        if (f.type === 'image') {
          handleFileChanges({ key: f.key, action: 'removeSingleImage' })
        } else if (f.type === 'files' || f.type === 'gallery') {
          if (!files.find((f) => f.name === file['name'])) {
            handleFileChanges({
              key: f.key,
              removedFilename: file['name'],
              action: 'updateRemovedFileList',
            })
          } else {
            files = files.filter((f) => f.name !== file['name'])
          }
        }
      }
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
  initialFiles: PropTypes.any,
  className: PropTypes.string,
  APIurl: PropTypes.string.isRequired,
  itemIdField: PropTypes.string.isRequired,
  rows: PropTypes.number,
  handleFileChanges: PropTypes.func,
}

FileUploader.displayName = 'FileUploader'

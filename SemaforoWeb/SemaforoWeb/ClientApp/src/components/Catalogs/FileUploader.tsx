import React, { forwardRef, HTMLAttributes } from 'react'
import PropTypes from 'prop-types'
import { dataColumn, dataItem } from '../../types'
import { CFormInput } from '@coreui/react-pro'

export interface FileUploadProps extends HTMLAttributes<HTMLDivElement> {
  itemData: dataItem
  f: dataColumn
  register: any
}

export const FileUpload = forwardRef<HTMLDivElement, FileUploadProps>(
  ({ itemData, f, register }, ref) => {
    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }
    return (
      <CFormInput
        {...register(toLower(f.key), {
          required: f.required || false,
        })}
        type="file"
        id={'file-' + f.key}
        size="sm"
      />
    )
  },
)

FileUpload.propTypes = {
  itemData: PropTypes.any.isRequired,
  f: PropTypes.any.isRequired,
  register: PropTypes.func.isRequired,
}

FileUpload.displayName = 'FileUpload'

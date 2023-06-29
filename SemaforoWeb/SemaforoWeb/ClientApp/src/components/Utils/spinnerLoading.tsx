import React, { HTMLAttributes, forwardRef, useState, useEffect } from 'react'
import PropTypes from 'prop-types'
import { CSpinner } from '@coreui/react-pro'

export interface SpinnerLoadingProps extends HTMLAttributes<HTMLDivElement> {
  visible: boolean
  setVisible?: (visible: boolean) => void
  type: string
}

export const SpinnerLoading = forwardRef<HTMLDivElement, SpinnerLoadingProps>(
  ({ visible, setVisible, type }, ref) => {
    return (
      <div className="spinner-backdrop">
        <CSpinner
          variant={type === 'saving' ? 'border' : 'grow'}
          className="spinner-loading"
          color="primary"
        />
      </div>
    )
  },
)
SpinnerLoading.propTypes = {
  visible: PropTypes.bool.isRequired,
  setVisible: PropTypes.func,
  type: PropTypes.string.isRequired,
}

SpinnerLoading.displayName = 'SpinnerLoading'

import React, { forwardRef } from 'react'
import { CSpinner } from '@coreui/react-pro'

export const SpinnerLoading = forwardRef<HTMLDivElement>(() => {
  return (
    <div className="spinner-backdrop">
      <CSpinner variant="grow" className="spinner-loading" color="primary" />
    </div>
  )
})

SpinnerLoading.displayName = 'SpinnerLoading'

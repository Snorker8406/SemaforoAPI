import React, { HTMLAttributes, forwardRef, useContext } from 'react'
import { CSpinner } from '@coreui/react-pro'
import { LoaderContext } from '../shared/loaderContext'

export type LoaderProps = HTMLAttributes<HTMLDivElement>

export const Loader = forwardRef<HTMLDivElement, LoaderProps>(({}, ref) => {
  const { showLoader, type } = useContext(LoaderContext)
  if (showLoader) {
    return (
      <div className="spinner-backdrop">
        <CSpinner
          variant={type === 'saving' ? 'grow' : 'border'}
          className="spinner-loading"
          color="primary"
        />
      </div>
    )
  }
  return <></>
})
Loader.propTypes = {}

Loader.displayName = 'Loader'

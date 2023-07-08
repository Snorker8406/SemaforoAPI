import React, {
  createContext,
  Suspense,
  useContext,
  useMemo,
  useState,
} from 'react'
import { Navigate, Route, Routes } from 'react-router-dom'
import { SpinnerLoading } from './Utils/spinnerLoading'

// routes config
import routes from '../routes'
import { Loader } from './Utils/Loader'
import { LoaderContext } from './shared/loaderContext'

const AppContent = () => {
  const [showLoader, setShowLoader] = useState(false)
  const [type, setType] = useState('loading')
  const loaderValues: any = useMemo(
    () => ({ showLoader, setShowLoader, type, setType }),
    [showLoader, type],
  )

  return (
    <Suspense fallback={<SpinnerLoading />}>
      <LoaderContext.Provider value={loaderValues}>
        <Loader />
      </LoaderContext.Provider>
      <Routes>
        {routes.map((route, idx) => {
          return (
            route.component && (
              <Route
                key={idx}
                path={route.path}
                element={<route.component />}
              />
            )
          )
        })}
        <Route path="/" element={<Navigate to="dashboard" replace />} />
      </Routes>
    </Suspense>
  )
}

export default React.memo(AppContent)

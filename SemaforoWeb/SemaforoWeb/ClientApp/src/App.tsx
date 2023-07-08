import React, { Suspense } from 'react'
import { HashRouter, Route, Routes } from 'react-router-dom'
import './scss/style.scss'
import { SpinnerLoading } from './components/Utils/spinnerLoading'
import { AuthContextProvider } from './components/shared/AuthContext'

// Containers
const DefaultLayout = React.lazy(() => import('./layout/DefaultLayout'))
const Login = React.lazy(() => import('./views/pages/Login'))
const Register = React.lazy(() => import('./views/pages/Register'))
const Page404 = React.lazy(() => import('./views/pages/Page404'))
const Page500 = React.lazy(() => import('./views/pages/Page500'))

const App = (): JSX.Element => {
  return (
    <HashRouter>
      <Suspense fallback={<SpinnerLoading />}>
        <AuthContextProvider>
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/404" element={<Page404 />} />
            <Route path="/500" element={<Page500 />} />
            <Route path="*" element={<DefaultLayout />} />
          </Routes>
        </AuthContextProvider>
      </Suspense>
    </HashRouter>
  )
}

export default App

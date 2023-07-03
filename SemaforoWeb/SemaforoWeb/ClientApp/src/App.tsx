import React, { Component, Suspense } from 'react'
import { HashRouter, Route, Routes } from 'react-router-dom'
import './scss/style.scss'
import { SpinnerLoading } from './components/Utils/spinnerLoading'

// Containers
const DefaultLayout = React.lazy(() => import('./layout/DefaultLayout'))
const Login = React.lazy(() => import('./views/pages/Login'))
const Register = React.lazy(() => import('./views/pages/Register'))
const Page404 = React.lazy(() => import('./views/pages/Page404'))
const Page500 = React.lazy(() => import('./views/pages/Page500'))
class App extends Component {
  render(): JSX.Element {
    return (
      <HashRouter>
        <Suspense fallback={<SpinnerLoading />}>
          <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/404" element={<Page404 />} />
            <Route path="/500" element={<Page500 />} />
            <Route path="*" element={<DefaultLayout />} />
          </Routes>
        </Suspense>
      </HashRouter>
    )
  }
}

export default App

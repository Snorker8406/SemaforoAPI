import React, { Component, Suspense } from 'react'
import { HashRouter, Route, Routes } from 'react-router-dom'
import './scss/style.scss'
import { SpinnerLoading } from './components/Utils/spinnerLoading'

// Containers
const DefaultLayout = React.lazy(() => import('./layout/DefaultLayout'))

class App extends Component {
  render(): JSX.Element {
    return (
      <HashRouter>
        <Suspense fallback={<SpinnerLoading visible={true} type="loading" />}>
          <Routes>
            <Route path="*" element={<DefaultLayout />} />
          </Routes>
        </Suspense>
      </HashRouter>
    )
  }
}

export default App

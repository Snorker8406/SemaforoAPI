import React, { useContext } from 'react'
import { Navigate } from 'react-router-dom'
import {
  AppAside,
  AppContent,
  AppSidebar,
  AppFooter,
  AppHeader,
} from '../components/index'
import AuthContext from '../components/shared/AuthContext'

const DefaultLayout = (): JSX.Element => {
  const { user } = useContext(AuthContext) as any

  if (!user) return <Navigate to="/login" />
  return (
    <>
      <AppSidebar />
      <div className="wrapper d-flex flex-column min-vh-100 bg-light dark:bg-transparent">
        <AppHeader />
        <div className="body flex-grow-1 px-3">
          <AppContent />
        </div>
        <AppFooter />
      </div>
      <AppAside />
    </>
  )
}

export default DefaultLayout

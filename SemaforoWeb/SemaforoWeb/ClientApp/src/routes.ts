import React, { ReactNode } from 'react'

export type route = {
  component?: ReactNode
  name?: string
  path?: string
  routes?: route[]
}

// examples
const Dashboard = React.lazy(() => import('./views/dashboard/Dashboard'))
const Blank = React.lazy(() => import('./views/blank/Blank'))
const Supplier = React.lazy(() => import('./views/suppliers/Supplier'))

/**
 * See {@link https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config GitHub}.
 */
const routes = [
  { path: '/', name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/blank', name: 'Blank', component: Blank },
  { path: '/suppliers', name: 'Supplier', component: Supplier },
  { path: '/suppliers/register', name: 'Register', component: Supplier },
]

export default routes

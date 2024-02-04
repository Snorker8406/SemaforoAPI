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
const Provider = React.lazy(() => import('./views/providers/Provider'))
const Client = React.lazy(() => import('./views/clients/Client'))
const Brand = React.lazy(() => import('./views/brands/Brand'))
const Employee = React.lazy(() => import('./views/employees/employee'))

/**
 * See {@link https://github.com/ReactTraining/react-router/tree/master/packages/react-router-config GitHub}.
 */
const routes = [
  { path: '/', name: 'Home' },
  { path: '/dashboard', name: 'Dashboard', component: Dashboard },
  { path: '/blank', name: 'Blank', component: Blank },
  { path: '/catalogs', name: 'Catalogs', component: Provider },
  { path: '/catalogs/providers', name: 'Provider', component: Provider },
  { path: '/catalogs/clients', name: 'Client', component: Client },
  { path: '/catalogs/brands', name: 'Brand', component: Brand },
  { path: '/catalogs/employees', name: 'Employee', component: Employee },
]

export default routes

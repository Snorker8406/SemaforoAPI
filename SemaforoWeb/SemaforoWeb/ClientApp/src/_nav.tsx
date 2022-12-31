import React from 'react'
import { cilSpeedometer, cilFlightTakeoff } from '@coreui/icons'
import CIcon from '@coreui/icons-react'
import { CNavItem } from '@coreui/react-pro'
import { ElementType } from 'react'

export type Badge = {
  color: string
  text: string
}

export type NavItem = {
  component: string | ElementType
  name: string | JSX.Element
  icon?: string | JSX.Element
  badge?: Badge
  to: string
  items?: NavItem[]
}

const _nav = [
  {
    component: CNavItem,
    name: 'Dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    badge: {
      color: 'info-gradient',
      text: 'NEW',
    },
    to: '/dashboard',
  },
  {
    component: CNavItem,
    name: 'Blank',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    to: '/blank',
  },
  {
    component: CNavItem,
    name: 'Proveedores',
    to: '/suppliers',
    icon: <CIcon icon={cilFlightTakeoff} customClassName="nav-icon" />,
  },
]

export default _nav

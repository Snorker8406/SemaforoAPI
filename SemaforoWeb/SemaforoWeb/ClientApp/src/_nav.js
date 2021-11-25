import React from 'react'
import CIcon from '@coreui/icons-react'
import {
  cilBell,
  cilCalculator,
  cilChartPie,
  cilCursor,
  cilDrop,
  cilNotes,
  cilPencil,
  cilPuzzle,
  cilSpeedometer,
  cilStar,
  cilBasket,
  cilUser,
  cilPeople,
  cilFlightTakeoff,
  cilEducation,
  cilHouse,
  cibTeespring,
  cilContact,
} from '@coreui/icons'
import { CNavGroup, CNavItem, CNavTitle } from '@coreui/react'

const _nav = [
  {
    component: CNavItem,
    name: 'Dashboard',
    to: '/dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    badge: {
      color: 'info',
      text: 'NEW',
    },
  },

  //Catalogo
  {
    component: CNavTitle,
    name: 'Catalog',
  },
  {
    component: CNavGroup,
    name: 'Products',
    to: '/base/popovers',
    icon: <CIcon icon={cilBasket} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'List of Products',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Product Register',
        to: '/base/accordion',
      },
      {
        component: CNavGroup,
        name: 'Product Entry',
        to: '/base/accordion',
        items: [
          {
            component: CNavItem,
            name: 'Unique Products',
            to: '/base/accordion',
          },
          {
            component: CNavItem,
            name: 'Orders',
            to: '/base/accordion',
          },
        ],
      },
      {
        component: CNavItem,
        name: 'Search Products',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Season for Stock',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Set Stock',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Stock report',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Manage Stock',
        to: '/base/accordion',
      },
      {
        component: CNavGroup,
        name: 'Print Labels',
        to: '/base/accordion',
        items: [
          {
            component: CNavItem,
            name: 'Standard Code',
            to: '/base/accordion',
          },
          {
            component: CNavItem,
            name: 'EAN13',
            to: '/base/accordion',
          },
        ],
      },
      {
        component: CNavItem,
        name: 'Discount',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Review by Product',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Manage Concepts',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Clients',
    icon: <CIcon icon={cilPeople} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Clients Register',
        to: '/forms/registerClient',
      },
      {
        component: CNavItem,
        name: 'List of Clients',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Manage Accounts Receivable',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Employees',
    to: '/theme/colors',
    icon: <CIcon icon={cilUser} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Manage Employees',
        to: '/forms/manageEmployees',
      },
      {
        component: CNavItem,
        name: 'Employee Permits',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Payment to Employees',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Rectify Attendance',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Attendance',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Providers',
    to: '/base/accordion',
    icon: <CIcon icon={cilFlightTakeoff} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Manage Suppliers',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Debts to Pay',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Payments',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Schools',
    to: '/base/paginations',
    icon: <CIcon icon={cilEducation} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Schools List',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Schools Register',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'School Sign',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Embroidery',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Stores',
    to: '/base/spinners',
    icon: <CIcon icon={cilHouse} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Manage Stores',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Embroidery',
    to: '/base/tooltips',
    icon: <CIcon icon={cibTeespring} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Embroidery Register',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Search Embroidery',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavItem,
    name: 'Users',
    to: '/forms/users',
    icon: <CIcon icon={cilContact} customClassName="nav-icon" />,
  },

  //Componentes
  {
    component: CNavTitle,
    name: 'Components',
  },
  {
    component: CNavGroup,
    name: 'Base',
    to: '/base',
    icon: <CIcon icon={cilPuzzle} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Accordion',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Breadcrumb',
        to: '/base/breadcrumbs',
      },
      {
        component: CNavItem,
        name: 'Cards',
        to: '/base/cards',
      },
      {
        component: CNavItem,
        name: 'Carousel',
        to: '/base/carousels',
      },
      {
        component: CNavItem,
        name: 'Collapse',
        to: '/base/collapses',
      },
      {
        component: CNavItem,
        name: 'List group',
        to: '/base/list-groups',
      },
      {
        component: CNavItem,
        name: 'Navs & Tabs',
        to: '/base/navs',
      },
      {
        component: CNavItem,
        name: 'Pagination',
        to: '/base/paginations',
      },
      {
        component: CNavItem,
        name: 'Popovers',
        to: '/base/popovers',
      },
      {
        component: CNavItem,
        name: 'Progress',
        to: '/base/progress',
      },
      {
        component: CNavItem,
        name: 'Spinners',
        to: '/base/spinners',
      },
      {
        component: CNavItem,
        name: 'Tables',
        to: '/base/tables',
      },
      {
        component: CNavItem,
        name: 'Tooltips',
        to: '/base/tooltips',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Buttons',
    to: '/buttons',
    icon: <CIcon icon={cilCursor} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Buttons',
        to: '/buttons/buttons',
      },
      {
        component: CNavItem,
        name: 'Buttons groups',
        to: '/buttons/button-groups',
      },
      {
        component: CNavItem,
        name: 'Dropdowns',
        to: '/buttons/dropdowns',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Forms',
    icon: <CIcon icon={cilNotes} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Form Control',
        to: '/forms/form-control',
      },
      {
        component: CNavItem,
        name: 'Select',
        to: '/forms/select',
      },
      {
        component: CNavItem,
        name: 'Checks & Radios',
        to: '/forms/checks-radios',
      },
      {
        component: CNavItem,
        name: 'Range',
        to: '/forms/range',
      },
      {
        component: CNavItem,
        name: 'Input Group',
        to: '/forms/input-group',
      },
      {
        component: CNavItem,
        name: 'Floating Labels',
        to: '/forms/floating-labels',
      },
      {
        component: CNavItem,
        name: 'Layout',
        to: '/forms/layout',
      },
      {
        component: CNavItem,
        name: 'Validation',
        to: '/forms/validation',
      },
    ],
  },
  {
    component: CNavItem,
    name: 'Charts',
    to: '/charts',
    icon: <CIcon icon={cilChartPie} customClassName="nav-icon" />,
  },
  {
    component: CNavGroup,
    name: 'Icons',
    icon: <CIcon icon={cilStar} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'CoreUI Free',
        to: '/icons/coreui-icons',
        badge: {
          color: 'success',
          text: 'NEW',
        },
      },
      {
        component: CNavItem,
        name: 'CoreUI Flags',
        to: '/icons/flags',
      },
      {
        component: CNavItem,
        name: 'CoreUI Brands',
        to: '/icons/brands',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Notifications',
    icon: <CIcon icon={cilBell} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Alerts',
        to: '/notifications/alerts',
      },
      {
        component: CNavItem,
        name: 'Badges',
        to: '/notifications/badges',
      },
      {
        component: CNavItem,
        name: 'Modal',
        to: '/notifications/modals',
      },
      {
        component: CNavItem,
        name: 'Toasts',
        to: '/notifications/toasts',
      },
    ],
  },
  {
    component: CNavItem,
    name: 'Widgets',
    to: '/widgets',
    icon: <CIcon icon={cilCalculator} customClassName="nav-icon" />,
    badge: {
      color: 'info',
      text: 'NEW',
    },
  },
  {
    component: CNavTitle,
    name: 'Extras',
  },
  {
    component: CNavGroup,
    name: 'Pages',
    icon: <CIcon icon={cilStar} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Login',
        to: '/login',
      },
      {
        component: CNavItem,
        name: 'Register',
        to: '/register',
      },
      {
        component: CNavItem,
        name: 'Error 404',
        to: '/404',
      },
      {
        component: CNavItem,
        name: 'Error 500',
        to: '/500',
      },
    ],
  },
]

export default _nav

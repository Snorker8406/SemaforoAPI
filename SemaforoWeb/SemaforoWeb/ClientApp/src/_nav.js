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
    name: 'Catálogo',
  },
  {
    component: CNavGroup,
    name: 'Productos',
    to: '/base/popovers',
    icon: <CIcon icon={cilBasket} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Listado de Productos',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Registro de Productos',
        to: '/base/accordion',
      },
      {
        component: CNavGroup,
        name: 'Entrada de Productos',
        to: '/base/accordion',
        items: [
          {
            component: CNavItem,
            name: 'Productos Unicos',
            to: '/base/accordion',
          },
          {
            component: CNavItem,
            name: 'Pedidos',
            to: '/base/accordion',
          },
        ],
      },
      {
        component: CNavItem,
        name: 'Buscar Productos',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Temporadas para Stock',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Establecer Stock',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Reporte de Stocks',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Administrar Existencias',
        to: '/base/accordion',
      },
      {
        component: CNavGroup,
        name: 'Imprimir Etiquetas',
        to: '/base/accordion',
        items: [
          {
            component: CNavItem,
            name: 'Codigo Standar',
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
        name: 'Descuentos',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Revision por Producto',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Administrar Conceptos',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Clientes',
    icon: <CIcon icon={cilPeople} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Registro de Clientes',
        to: '/forms/registerClient',
      },
      {
        component: CNavItem,
        name: 'Listado de Clientes',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Administrar Cuentas por Cobrar',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Empleados',
    to: '/theme/colors',
    icon: <CIcon icon={cilUser} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Administrar Empleados',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Permisos a Empleados',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Pagos a Empleados',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Rectificar Asistencias',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Asistencia',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Proveedores',
    to: '/base/accordion',
    icon: <CIcon icon={cilFlightTakeoff} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Administrar Proveedores',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Cuentas por Pagar',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Pagos',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Escuelas',
    to: '/base/paginations',
    icon: <CIcon icon={cilEducation} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Listado de Escuelas',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Registro de Escuelas',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Letreros de Escuelas',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Ponchados',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Sucursales',
    to: '/base/spinners',
    icon: <CIcon icon={cilHouse} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Administrar Sucursales',
        to: '/base/accordion',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Ponchados',
    to: '/base/tooltips',
    icon: <CIcon icon={cibTeespring} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Registro de Ponchados',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Buscar Ponchados',
        to: '/base/accordion',
      },
    ],
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

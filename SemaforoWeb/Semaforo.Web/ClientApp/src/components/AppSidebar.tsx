import React from 'react'
import { useDispatch } from 'react-redux'
import {
  CSidebar,
  CSidebarBrand,
  CSidebarNav,
  CSidebarToggler,
} from '@coreui/react-pro'

import { useTypedSelector } from '../store'

import { AppSidebarNav } from './AppSidebarNav'

import CIcon from '@coreui/icons-react'

import SimpleBar from 'simplebar-react'
import 'simplebar/dist/simplebar.min.css'

import brand from '../assets/brand/brand.png'
// sidebar nav config
import navigation from '../_nav'

const AppSidebar = () => {
  const dispatch = useDispatch()
  const unfoldable = useTypedSelector((state) => state.sidebarUnfoldable)
  const sidebarShow = useTypedSelector((state) => state.sidebarShow)

  return (
    <CSidebar
      position="fixed"
      unfoldable={unfoldable}
      visible={sidebarShow}
      onVisibleChange={(visible) => {
        dispatch({ type: 'set', sidebarShow: visible })
      }}
    >
      <CSidebarBrand className="d-none d-md-flex">
        <img src={brand} alt="marca" width={180}></img>
      </CSidebarBrand>
      <CSidebarNav>
        <SimpleBar>
          <AppSidebarNav items={navigation} />
        </SimpleBar>
      </CSidebarNav>
      <CSidebarToggler
        className="d-none d-lg-flex"
        onClick={() =>
          dispatch({ type: 'set', sidebarUnfoldable: !unfoldable })
        }
      />
    </CSidebar>
  )
}

export default React.memo(AppSidebar)

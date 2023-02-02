import React from 'react'
import API from '../../API'
import { ItemsTable } from '../../components/Catalogs/ItemsTable'
import { CCol, CRow } from '@coreui/react-pro'

const Brand = () => {
  const BrandTable = () => {
    return (
      <ItemsTable APIurl={API.brands.APIurl} idField={API.brands.idField} />
    )
  }
  return (
    <div id="brands-table">
      <CRow>
        <CCol xs={12}>
          <h1>Marcas</h1>
        </CCol>
        <CCol xs={12}>{BrandTable()}</CCol>
      </CRow>
    </div>
  )
}

export default Brand

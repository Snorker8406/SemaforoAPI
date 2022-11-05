import React from 'react'
import API from '../../API'
import ItemsList from 'src/components/Catalogs/ItemsList'
import { CCol, CRow, CContainer } from '@coreui/react'

const Supplier = () => {
  const supplierTable = () => {
    return <ItemsList APIurl={API.providers.APIurl} IdField={API.providers.IdField} />
  }
  return (
    <CContainer>
      <CRow>
        <CCol xs={12}>
          <h1>Proveedores</h1>
        </CCol>
        <CCol xs={12}>{supplierTable()}</CCol>
      </CRow>
    </CContainer>
  )
}

export default Supplier

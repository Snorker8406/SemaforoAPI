import React from 'react'
import API from '../../API'
import { ItemsTable } from '../../components/Catalogs/ItemsTable'
import { CCol, CRow } from '@coreui/react-pro'

const Provider = () => {
  const ProviderTable = () => {
    return (
      <ItemsTable
        APIurl={API.providers.APIurl}
        idField={API.providers.idField}
      />
    )
  }
  return (
    <div id="providers-table">
      <CRow>
        <CCol xs={12}>
          <h1>Proveedores</h1>
        </CCol>
        <CCol xs={12}>{ProviderTable()}</CCol>
      </CRow>
    </div>
  )
}

export default Provider

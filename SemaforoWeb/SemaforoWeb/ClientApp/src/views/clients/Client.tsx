import React from 'react'
import API from '../../API'
import { ItemsTable } from '../../components/Catalogs/ItemsTable'
import { CCol, CRow } from '@coreui/react-pro'

const Client = () => {
  const ClientTable = () => {
    return (
      <ItemsTable APIurl={API.clients.APIurl} idField={API.clients.idField} />
    )
  }
  return (
    <div id="clients-table">
      <CRow>
        <CCol xs={12}>
          <h1>Clientes</h1>
        </CCol>
        <CCol xs={12}>{ClientTable()}</CCol>
      </CRow>
    </div>
  )
}

export default Client

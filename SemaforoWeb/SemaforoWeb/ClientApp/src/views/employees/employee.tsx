import React from 'react'
import API from '../../API'
import { ItemsTable } from '../../components/Catalogs/ItemsTable'
import { CCol, CRow } from '@coreui/react-pro'

const Employee = () => {
  const EmployeeTable = () => {
    return (
      <ItemsTable
        APIurl={API.employees.APIurl}
        idField={API.employees.idField}
      />
    )
  }
  return (
    <div id="employee-table">
      <CRow>
        <CCol xs={12}>
          <h1>Empleados</h1>
        </CCol>
        <CCol xs={12}>{EmployeeTable()}</CCol>
      </CRow>
    </div>
  )
}

export default Employee

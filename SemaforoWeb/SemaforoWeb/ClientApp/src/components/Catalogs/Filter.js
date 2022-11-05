import React from 'react'
import {
  CButton,
  CCol,
  CForm,
  CFormInput,
  CFormLabel,
  CFormSelect,
  CInputGroup,
  CInputGroupText,
} from '@coreui/react'

const Filter = () => {
  return (
    <CForm className="row gx-3 gy-2 align-items-center">
      <CCol sm={3}>
        <CFormLabel className="visually-hidden" htmlFor="specificSizeInputName">
          Name
        </CFormLabel>
        <CFormInput id="specificSizeInputName" placeholder="Filtrar" />
      </CCol>
      <CCol sm={3}>
        <CFormLabel className="visually-hidden" htmlFor="specificSizeInputGroupUsername">
          Username
        </CFormLabel>
        <CInputGroup>
          <CInputGroupText>@</CInputGroupText>
          <CFormInput id="specificSizeInputGroupUsername" placeholder="Username" />
        </CInputGroup>
      </CCol>
      <CCol sm={3}>
        <CFormLabel className="visually-hidden" htmlFor="specificSizeSelect">
          Preference
        </CFormLabel>
        <CFormSelect id="specificSizeSelect">
          <option>Choose...</option>
          <option value="1">One</option>
          <option value="2">Two</option>
          <option value="3">Three</option>
        </CFormSelect>
      </CCol>
      <CCol xs="auto">
        <CButton type="submit">Filtrar</CButton>
      </CCol>
    </CForm>
  )
}
export default Filter

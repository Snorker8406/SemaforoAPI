import React, { useState } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CForm,
  CFormCheck,
  CFormInput,
  CFormFeedback,
  CFormLabel,
  CFormSelect,
  CFormTextarea,
  CInputGroup,
  CInputGroupText,
  CRow,
  CImage,
  CContainer,
} from '@coreui/react'

const ClientForm = () => {
  const [validated, setValidated] = useState(false)
  const handleSubmit = (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
  }
  return (
    <CForm
      className="row g-3 needs-validation"
      noValidate
      validated={validated}
      onSubmit={handleSubmit}
    >
      <CContainer>
        <CRow>
          <CFormLabel htmlFor="validationCustom03">Client</CFormLabel>
        </CRow>
        <CRow>
          <CCol>
            <CRow>
              <CFormLabel htmlFor="validationCustom03">Name</CFormLabel>
              <div className="col-lg-12">
                <CFormInput type="text" id="validationCustom01" placeholder="Enter name" required />
              </div>
            </CRow>
          </CCol>
          <CCol>
            <CRow>
              <CFormLabel htmlFor="validationCustom03">Last Name</CFormLabel>
              <div className="col-sm-12">
                <CFormInput
                  type="text"
                  id="validationCustom01"
                  placeholder="Enter last name"
                  required
                />
              </div>
            </CRow>
          </CCol>
          <CCol>
            <CRow>
              <CFormLabel htmlFor="validationCustom03">Last Name Mother</CFormLabel>
              <div className="col-sm-12">
                <CFormInput
                  type="text"
                  id="validationCustom01"
                  placeholder="Enter last name mother"
                  required
                />
              </div>
            </CRow>
          </CCol>
          {/* <CCol xs={3}>
            <div className="clearfix">
              <CImage align="start" rounded src="/images/react400.jpg" width={250} height={250} />
            </div>
          </CCol> */}
        </CRow>
        <br />
        <CRow>
          <CCol xs={2}>
            <CFormLabel htmlFor="validationCustom03">Date of birth</CFormLabel>
            <CFormInput type="date" id="validationCustom01" value="2021-11-19" required />
          </CCol>
          <CCol xs={2}>
            <CFormLabel htmlFor="validationCustom03">Sexo</CFormLabel>
            <CFormCheck
              type="radio"
              name="flexRadioDefault"
              id="flexRadioDefault1"
              label="Hombre"
            />
            <CFormCheck type="radio" name="flexRadioDefault" id="flexRadioDefault1" label="Mujer" />
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Address</CFormLabel>
            <CFormInput type="text" id="validationCustom01" placeholder="Enter Address" required />
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Cellphone</CFormLabel>
            <CFormInput
              type="text"
              id="validationCustom01"
              placeholder="Enter Cellphone"
              required
            />
          </CCol>
        </CRow>
      </CContainer>
    </CForm>
  )
}

const registerClient = () => {
  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Validation</strong> <small>Custom styles</small>
          </CCardHeader>
          <CCardBody>{ClientForm()}</CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default registerClient

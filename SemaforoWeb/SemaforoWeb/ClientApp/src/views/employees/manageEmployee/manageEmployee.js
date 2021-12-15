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
  CFormLabel,
  CFormSelect,
  CRow,
  CImage,
  CContainer,
  CFormTextarea,
} from '@coreui/react'
import { DatasetController } from 'chart.js'

const EmployeeForm = () => {
  // const clientSubmit = (event) => {
  //   event.preventDefault()
  //   fetch('/api/Client', {
  //     method: 'POST',
  //     headers: {
  //       'Content-Type': 'application/json',
  //     },
  //     body: JSON.stringify(data),
  //   })
  //     .then((res) => res.json())
  //     .then((result) => {
  //       console.log(result)
  //       setData(result)
  //     })
  //     .catch((err) => console.log('error'))
  //   console.log(data.name)
  // }

  return (
    <form /*onSubmit={clientSubmit}*/>
      <CContainer>
        <CRow>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Name of Employee</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">First Last Name</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Second Last Name</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
        </CRow>
        <br />
        <CRow>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">BirthDay</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Gender</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Address</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Cellphone</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
          <CCol>
            <CFormLabel htmlFor="validationCustom03">Active</CFormLabel>
            <div className="col-lg-12">
              <CFormInput type="text" name="name" />
            </div>
          </CCol>
        </CRow>
        <br />
        <CRow>
          <CFormLabel htmlFor="validationCustom03">Comments</CFormLabel>
          <CFormTextarea rows="3"></CFormTextarea>
        </CRow>
        <br />
        <CRow>
          <CCol>
            <CButton color="primary" shape="rounded-pill" type="submit" name="clientSubmit">
              Submit
            </CButton>
          </CCol>
        </CRow>
      </CContainer>
    </form>
  )
}

const manageEmployee = () => {
  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Manage</strong> <small>Employee</small>
          </CCardHeader>
          <CCardBody>{EmployeeForm()}</CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default manageEmployee

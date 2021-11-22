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
} from '@coreui/react'
import { DatasetController } from 'chart.js'

const ClientForm = () => {
  const [data, setData] = useState({
    clientName: '',
    clientLastName: '',
    clientLastNameMother: '',
    clientDateOfBirth: '',
    clientMale: '',
    clientFemale: '',
    clientAddress: '',
    clientCellphone: '',
    clientEmail: '',
    clientFacebook: '',
    clientAccountDaysLimit: '',
    clientAccountAmountLimit: '',
    clientStatus: '',
    clientLastModify: '',
    clientLastModifyBy: '',
  })

  const handleInputChange = (event) => {
    setData({
      ...data,
      [event.target.name]: event.target.value,
    })
  }

  const clientSubmit = (event) => {
    event.preventDefault()
    console.log(data.clientName)
  }
  return (
    <form onSubmit={clientSubmit}>
      <CContainer>
        <CRow>
          <CFormLabel htmlFor="validationCustom03">Name of client</CFormLabel>
        </CRow>
        <CCol xs={12}>
          <CRow>
            <CCol>
              <CRow>
                <CFormLabel htmlFor="validationCustom03">Name</CFormLabel>
                <div className="col-lg-12">
                  <CFormInput
                    type="text"
                    name="clientName"
                    placeholder="Enter name"
                    onChange={handleInputChange}
                    required
                  />
                </div>
              </CRow>
            </CCol>
            <CCol>
              <CRow>
                <CFormLabel htmlFor="validationCustom03">Last Name</CFormLabel>
                <div className="col-sm-12">
                  <CFormInput
                    type="text"
                    name="clientLastname"
                    placeholder="Enter last name"
                    onChange={handleInputChange}
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
                    name="clientLastNameMother"
                    placeholder="Enter last name mother"
                    onChange={handleInputChange}
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
              <CFormInput
                type="date"
                name="clientDateOfBirth"
                value="2021-11-19"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol xs={2}>
              <CFormLabel htmlFor="validationCustom03">Gender</CFormLabel>
              <CFormCheck type="radio" name="clientMale" label="Male" />
              <CFormCheck type="radio" name="clienteFemale" label="Female" />
            </CCol>
            <CCol>
              <CFormLabel htmlFor="validationCustom03">Address</CFormLabel>
              <CFormInput
                type="text"
                name="clientAddress"
                placeholder="Enter Address"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol>
              <CFormLabel htmlFor="validationCustom03">Cellphone</CFormLabel>
              <CFormInput
                type="number"
                name="clientCellphone"
                placeholder="Enter Cellphone"
                onChange={handleInputChange}
                required
              />
            </CCol>
          </CRow>
          <br />
          <CRow>
            <CCol xs={3}>
              <CFormLabel htmlFor="validationCustom03">Email</CFormLabel>
              <CFormInput
                type="text"
                name="clientEmail"
                placeholder="Enter email"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol xs={3}>
              <CFormLabel htmlFor="validationCustom03">Facebook</CFormLabel>
              <CFormInput
                type="text"
                name="clientFacebook"
                placeholder="Enter Facebook profile"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol>
              <CFormLabel htmlFor="validationCustom03">Account Days Limit</CFormLabel>
              <div className="col-sm-12">
                <CFormInput
                  type="number"
                  name="clientAccountDaysLimit"
                  placeholder="Place the account days limit"
                  onChange={handleInputChange}
                  required
                />
              </div>
            </CCol>
            <CCol>
              <CFormLabel htmlFor="validationCustom03">Account Amount Limit</CFormLabel>
              <div className="col-sm-12">
                <CFormInput
                  type="number"
                  name="clientAccountAmountLimit"
                  placeholder="Place the account amount limit"
                  onChange={handleInputChange}
                  required
                />
              </div>
            </CCol>
          </CRow>
          <br />
          <CRow>
            <CCol xs={2}>
              <CFormLabel htmlFor="validationCustom03">Status</CFormLabel>
              <CFormSelect
                aria-label="Default select example"
                name="clientStatus"
                onChange={handleInputChange}
              >
                <option disabled>Choose</option>
                <option value="1">Active</option>
                <option value="2">Inactive</option>
              </CFormSelect>
            </CCol>
            <CCol xs={2}>
              <CFormLabel htmlFor="validationCustom03">Last Modify</CFormLabel>
              <CFormInput
                type="date"
                name="clientLastModify"
                placeholder="Enter email"
                value="2021-11-19"
                readonly
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol xs={2}>
              <CFormLabel htmlFor="validationCustom03">Last Modify By</CFormLabel>
              <CFormInput
                type="text"
                name="clientLastModifyBy"
                disabled
                readonly
                onChange={handleInputChange}
                required
              />
            </CCol>
          </CRow>
          <br />
          <CRow>
            <CCol>
              <CButton color="primary" shape="rounded-pill" type="submit" name="clientSubmit">
                Submit
              </CButton>
            </CCol>
          </CRow>
        </CCol>
      </CContainer>
    </form>
  )
}

const registerClient = () => {
  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Client</strong> <small>Register</small>
          </CCardHeader>
          <CCardBody>{ClientForm()}</CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default registerClient

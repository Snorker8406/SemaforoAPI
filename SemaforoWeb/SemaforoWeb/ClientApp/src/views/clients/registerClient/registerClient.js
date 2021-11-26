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

const ClientForm = () => {
  const [data, setData] = useState({
    clientStatusId: 1,
    userId: 1,
    lastModifiedBy: 1,
    status: '',
    name: '',
    lastName: '',
    lastNameMother: '',
    accountDaysLimit: 2,
    accountAmountLimit: 2.2,
    address: '',
    cellphone: '',
    whatsapp: true,
    facebook: '',
    email: '',
    profileImage: '',
    comments: '',
  })

  const handleInputChange = (event) => {
    setData({
      ...data,
      [event.target.name]: event.target.value,
    })
  }

  const clientSubmit = (event) => {
    event.preventDefault()
    fetch('/api/Client', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    })
      .then((res) => res.json())
      .then((result) => {
        console.log(result)
        setData(result)
      })
      .catch((err) => console.log('error'))
    console.log(data.name)
  }
  return (
    <form onSubmit={clientSubmit}>
      <CContainer>
        <CRow>
          <CFormLabel htmlFor="validationCustom03">
            {data.name} {data.lastName} {data.lastNameMother} {data.clientId}
          </CFormLabel>
        </CRow>
        <CCol xs={12}>
          <CRow>
            <CCol>
              <CRow>
                <CFormLabel htmlFor="validationCustom03">Name</CFormLabel>
                <div className="col-lg-12">
                  <CFormInput
                    type="text"
                    name="name"
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
                    name="lastName"
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
                    name="lastNameMother"
                    placeholder="Enter last name mother"
                    onChange={handleInputChange}
                    required
                  />
                </div>
              </CRow>
            </CCol>
          </CRow>
          <br />
          <CRow>
            <CCol xs={3}>
              <CFormLabel htmlFor="validationCustom03">Date of birth</CFormLabel>
              <CFormInput
                type="date"
                name="dateOfBirth"
                value="2021-11-19"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol xs={1}>
              <CFormLabel htmlFor="validationCustom03">Gender</CFormLabel>
              <CFormCheck type="radio" name="male" label="Male" />
              <CFormCheck type="radio" name="female" label="Female" />
            </CCol>
            <CCol>
              <CFormLabel htmlFor="validationCustom03">Address</CFormLabel>
              <CFormInput
                type="text"
                name="address"
                placeholder="Enter Address"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol>
              <CFormLabel htmlFor="validationCustom03">Cellphone</CFormLabel>
              <CFormInput
                type="number"
                name="cellphone"
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
                name="email"
                placeholder="Enter email"
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol xs={3}>
              <CFormLabel htmlFor="validationCustom03">Facebook</CFormLabel>
              <CFormInput
                type="text"
                name="facebook"
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
                  name="accountDaysLimit1"
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
                  name="accountAmountLimit1"
                  placeholder="Place the account amount limit"
                  onChange={handleInputChange}
                  required
                />
              </div>
            </CCol>
          </CRow>
          <br />
          <CRow>
            <CCol xs={4}>
              <CFormLabel htmlFor="validationCustom03">Status</CFormLabel>
              <CFormSelect
                aria-label="Default select example"
                name="status"
                onChange={handleInputChange}
              >
                <option disabled>Choose</option>
                <option value="1">Active</option>
                <option value="2">Inactive</option>
              </CFormSelect>
            </CCol>
            <CCol xs={4}>
              <CFormLabel htmlFor="validationCustom03">Last Modify</CFormLabel>
              <CFormInput
                type="date"
                name="lastModify"
                placeholder="Enter email"
                value="2021-11-19"
                readonly
                onChange={handleInputChange}
                required
              />
            </CCol>
            <CCol xs={4}>
              <CFormLabel htmlFor="validationCustom03">Last Modify By</CFormLabel>
              <CFormInput
                type="text"
                name="lastModifyBy"
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

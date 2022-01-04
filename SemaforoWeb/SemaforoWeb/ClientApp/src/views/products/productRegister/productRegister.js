import React, { useState } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCardHeader,
  CCol,
  CFormCheck,
  CFormInput,
  CFormLabel,
  CRow,
  CImage,
  CContainer,
  CFormTextarea,
  CFormFloating,
  CForm,
  CFormSelect,
} from '@coreui/react'

const ProductForm = () => {
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

  const schoolsSubmit = (event) => {
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
    <form onSubmit={schoolsSubmit}>
      <CContainer>
        <CRow>
          <CFormLabel htmlFor="validationCustom03">{data.name}</CFormLabel>
        </CRow>
        <CRow>
          <CCol xs={9}>
            <CRow>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">Provider</CFormLabel>
                <CFormSelect aria-label="Default select example">
                  <option disabled>Choose a provider</option>
                  <option value="1">AMARO ZARATE</option>
                  <option value="2">MARTHA PEREZ</option>
                  <option value="3">TABITAS</option>
                  <option value="3">TWINS</option>
                </CFormSelect>
              </CCol>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">Name of Product</CFormLabel>
                <CForm validated={true}>
                  <div className="col-lg-12">
                    <CFormInput
                      type="text"
                      name="name"
                      placeholder="Enter name of school"
                      onChange={handleInputChange}
                      invalid
                      required
                    />
                  </div>
                </CForm>
              </CCol>
            </CRow>
            <br />
            <CRow>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">Brand</CFormLabel>
                <CFormInput
                  type="text"
                  name="street"
                  placeholder="Enter Brand"
                  onChange={handleInputChange}
                  required
                />
              </CCol>
            </CRow>
            <br />
            <CRow>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">State</CFormLabel>
                <CFormInput
                  type="text"
                  name="state"
                  placeholder="Enter State"
                  onChange={handleInputChange}
                  required
                />
                <br />
                <CCol>
                  <CFormLabel htmlFor="validationCustom03">Regristation Date</CFormLabel>
                  <CFormInput
                    type="date"
                    name="lastModify"
                    placeholder="Enter email"
                    onChange={handleInputChange}
                    required
                  />
                </CCol>
              </CCol>
              <CCol xs={5}>
                <CFormLabel htmlFor="validationCustom03">Email</CFormLabel>
                <CFormInput
                  type="text"
                  name="email"
                  placeholder="Enter email"
                  onChange={handleInputChange}
                  required
                />
                <br />
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
                <br />
              </CCol>
              <CFormFloating>
                <CFormTextarea
                  placeholder="Leave a comment here"
                  id="floatingTextarea2"
                  style={{ height: '250px' }}
                ></CFormTextarea>
                <CFormLabel htmlFor="floatingTextarea2">Comments</CFormLabel>
              </CFormFloating>
            </CRow>
            <br />
            <CRow>
              <CCol>
                <CButton
                  color="success"
                  shape="rounded-pill"
                  type="submit"
                  variant="outline"
                  name="schoolsSubmit"
                >
                  Submit
                </CButton>
              </CCol>
            </CRow>
          </CCol>
          <CCol xs={3}>
            <CRow>
              <CButton
                color="warning"
                variant="outline"
                shape="rounded-pill"
                type="file"
                name="schoolsSubmit"
              >
                Upload Image
              </CButton>
            </CRow>
            <br />
            <CRow>
              <CImage
                fluid
                src="C:\Users\Guselio\Desktop\Semaforo\SemaforoAPI\SemaforoWeb\SemaforoWeb\ClientApp\src\assets\images\react.jpg"
                width={200}
                height={240}
              />
            </CRow>
          </CCol>
        </CRow>
      </CContainer>
    </form>
  )
}

const productRegister = () => {
  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>Product</strong> <small>Register</small>
          </CCardHeader>
          <CCardBody>{ProductForm()}</CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default productRegister
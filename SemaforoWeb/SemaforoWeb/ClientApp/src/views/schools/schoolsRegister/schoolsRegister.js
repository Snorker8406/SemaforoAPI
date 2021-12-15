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
} from '@coreui/react'

const SchoolForm = () => {
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
                <CForm validated={true}>
                  <CRow>
                    <CFormLabel htmlFor="validationCustom03">Name of school</CFormLabel>
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
                  </CRow>
                </CForm>
              </CCol>
            </CRow>
            <br />
            <CRow>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">Street</CFormLabel>
                <CFormInput
                  type="text"
                  name="street"
                  placeholder="Enter Street"
                  onChange={handleInputChange}
                  required
                />
              </CCol>
              <CCol xs={2}>
                <CFormLabel htmlFor="validationCustom03">Number</CFormLabel>
                <CFormInput
                  type="number"
                  name="email"
                  placeholder="#"
                  onChange={handleInputChange}
                  required
                />
              </CCol>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">Suburb</CFormLabel>
                <CFormInput
                  type="text"
                  name="suburb"
                  placeholder="Enter Suburb"
                  onChange={handleInputChange}
                  required
                />
              </CCol>
              <CCol>
                <CFormLabel htmlFor="validationCustom03">City</CFormLabel>
                <CFormInput
                  type="text"
                  name="cellphone"
                  placeholder="Enter City"
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
                  name="cellphone"
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
                    name="street"
                    placeholder="Enter Cellphone"
                    onChange={handleInputChange}
                    required
                  />
                </CCol>
              </CCol>
              <CCol xl={3}>
                <CFormLabel htmlFor="validationCustom03">Level</CFormLabel>
                <CFormCheck
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  label="Kinder garden"
                />
                <CFormCheck
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  label="primary school"
                />
                <CFormCheck
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  label="Middle School"
                />
                <CFormCheck
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  label="High School"
                />
                <CFormCheck
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  label="University"
                />
                <CFormCheck
                  type="radio"
                  name="flexRadioDefault"
                  id="flexRadioDefault1"
                  label="Other"
                />
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
                size="sm"
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
            <CFormFloating className="mb-3">
              <CFormInput type="text" id="floatingInput" placeholder="Name of principal" />
              <CFormLabel htmlFor="floatingInput">Principal</CFormLabel>
            </CFormFloating>
            <br />
            <CFormFloating className="mb-3">
              <CFormInput type="number" id="floatingInput" placeholder="Directors phone" />
              <CFormLabel htmlFor="floatingInput">Directors phone</CFormLabel>
            </CFormFloating>
            <br />
            <CFormFloating className="mb-3">
              <CFormInput type="text" id="floatingInput" placeholder="Directors phone" />
              <CFormLabel htmlFor="floatingInput">Secretary</CFormLabel>
            </CFormFloating>
          </CCol>
        </CRow>
      </CContainer>
    </form>
  )
}

const schoolsRegister = () => {
  return (
    <CRow>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader>
            <strong>School</strong> <small>Register</small>
          </CCardHeader>
          <CCardBody>{SchoolForm()}</CCardBody>
        </CCard>
      </CCol>
    </CRow>
  )
}

export default schoolsRegister

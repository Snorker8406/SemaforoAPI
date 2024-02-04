import React, { useContext, useEffect, useState } from 'react'
import { Navigate, useSearchParams } from 'react-router-dom'
import {
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CRow,
} from '@coreui/react-pro'
import AuthContext from '../../components/shared/AuthContext'
import API from '../../API'
import useFetch from '../../components/Utils/useFetch'

const ConfirmEmail = (): JSX.Element => {
  const { user, loadUser } = useContext(AuthContext) as any
  const [queryParameters] = useSearchParams()
  const registerAddress = API.registerUser.ConfirmEmailUrl.replace(
    '#uid',
    encodeURIComponent(queryParameters.get('userId') as string),
  ).replace('#cd', encodeURIComponent(queryParameters.get('code') as string))

  const [userResponse, confirmEmail] = useFetch(registerAddress, 'GET')

  useEffect(() => {
    ;(async function () {
      await confirmEmail()
    })()
  }, [])

  useEffect(() => {
    loadUser(userResponse)
  }, [userResponse])

  if (user) {
    return <Navigate to="/" />
  }
  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={8}>
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <h1>Confirmando Email...</h1>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default ConfirmEmail

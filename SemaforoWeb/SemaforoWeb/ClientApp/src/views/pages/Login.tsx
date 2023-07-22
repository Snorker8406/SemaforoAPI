import React, { useContext, useEffect, useState } from 'react'
import { Link, Navigate } from 'react-router-dom'
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked } from '@coreui/icons'
import AuthContext from '../../components/shared/AuthContext'
import { IResolveParams, LoginSocialFacebook } from 'reactjs-social-login'
import { FacebookLoginButton } from 'react-social-login-buttons'
import useFetch from '../../components/Utils/useFetch'
import API from '../../API'

const Login = (): JSX.Element => {
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const { loginApiCall, user, loadUser } = useContext(AuthContext) as any
  const [socialUser, socialLogin] = useFetch(API.login.SocialUrl, 'POST') as any

  const sendCredentials = async (username: string, password: string) => {
    loginApiCall(null, { username, password })
  }

  const onSocialLogin = async ({ provider, data }: IResolveParams) => {
    switch (provider) {
      case 'facebook':
        //register or login
        await socialLogin(null, { provider, data })
        break
      default:
        break
    }
  }

  useEffect(() => {
    loadUser(socialUser)
  }, [socialUser])

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
                  <CForm>
                    <h1>Login</h1>
                    <p className="text-medium-emphasis">Accesa a tu cuenta</p>
                    <CInputGroup className="mb-3">
                      <CInputGroupText>@</CInputGroupText>
                      <CFormInput
                        placeholder="Email/Usuario"
                        autoComplete="username"
                        value={username}
                        onChange={(e) => {
                          setUsername(e.target.value)
                        }}
                      />
                    </CInputGroup>
                    <CInputGroup className="mb-4">
                      <CInputGroupText>
                        <CIcon icon={cilLockLocked} />
                      </CInputGroupText>
                      <CFormInput
                        type="password"
                        placeholder="Contraseña"
                        autoComplete="current-password"
                        value={password}
                        onChange={(e) => {
                          setPassword(e.target.value)
                        }}
                      />
                    </CInputGroup>
                    <CRow>
                      <CCol xs={6}>
                        <CButton
                          color="primary"
                          className="px-4"
                          onClick={() => {
                            sendCredentials(username, password)
                          }}
                        >
                          Login
                        </CButton>
                      </CCol>
                      <CCol xs={6} className="text-right">
                        <CButton color="link" className="px-0">
                          olvidaste tu contraseña?
                        </CButton>
                      </CCol>
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
              <CCard
                className="text-white bg-primary py-5"
                style={{ width: '44%' }}
              >
                <CCardBody className="text-center">
                  <div>
                    <h2>Registrate!</h2>
                    <p>si no tienes una cuenta creada obten una.</p>
                    <Link to="/register">
                      <CButton
                        color="primary"
                        className="mt-3"
                        active
                        tabIndex={-1}
                      >
                        Registrate ahora!
                      </CButton>
                    </Link>
                  </div>
                  <h2>ó</h2>
                  <CRow>
                    <LoginSocialFacebook
                      appId={process.env.REACT_APP_FB_APP_ID || ''}
                      fieldsProfile={
                        'id,first_name,last_name,middle_name,name,name_format,picture,short_name,email,gender,birthday'
                      }
                      // onLoginStart={onLoginStart}
                      // onLogoutSuccess={onLogoutSuccess}
                      // redirect_uri={REDIRECT_URI}
                      onResolve={onSocialLogin}
                      onReject={(err) => {
                        console.log(err)
                      }}
                    >
                      <FacebookLoginButton text="Entra con Facebook" />
                    </LoginSocialFacebook>
                  </CRow>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Login

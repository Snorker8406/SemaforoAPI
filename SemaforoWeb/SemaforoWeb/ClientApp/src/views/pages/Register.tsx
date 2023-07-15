import React, { HTMLAttributes, useEffect, useState } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CFormText,
  CInputGroup,
  CInputGroupText,
  CRow,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import { SubmitHandler, useForm } from 'react-hook-form'
import { useFetch } from '../../components/Utils/useFetch'
import API from '../../API'

type Inputs = {
  name: string
  firstLastName: string
  secondLastName: string
  email: string
  password: string
  passwordConfirmed: string
}

const Register = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<any>()
  const [message, registerUser] = useFetch(API.registerUser.APIurl, 'POST')
  const [confirmedPass, setConfirmedPass] = useState(false)
  const [userTaken, setUserTaken] = useState(false)
  const [response, setResponse] = useState('')
  const sendUserInfo: SubmitHandler<Inputs> = async (data) => {
    setConfirmedPass(data['passwordConfirmed'] === data['password'])
    if (data['passwordConfirmed'] === data['password']) {
      // enviar
      console.log(data)
      await registerUser(null, data)
      setResponse(message)
    }
  }
  useEffect(() => {
    if (response && response.indexOf('correo electronico') > 0) {
      reset()
    }
  }, [message])
  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9} lg={7} xl={6}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm onSubmit={handleSubmit(sendUserInfo)}>
                  <h1>Registrate!</h1>
                  <p className="text-medium-emphasis">Crea tu cuenta</p>
                  {errors['name'] && (
                    <CFormText component="span">
                      {errors['name']?.type === 'required' &&
                        'Este campo es obligatorio.'}
                    </CFormText>
                  )}
                  <CInputGroup className="mb-3">
                    <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText>
                    <CFormInput
                      {...register('name', {
                        required: true,
                      })}
                      placeholder="Nombre"
                      autoComplete="name"
                    />
                  </CInputGroup>
                  {errors['firstLastName'] && (
                    <CFormText component="span">
                      {errors['firstLastName']?.type === 'required' &&
                        'Este campo es obligatorio.'}
                    </CFormText>
                  )}
                  <CInputGroup className="mb-3">
                    <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText>
                    <CFormInput
                      {...register('firstLastName', {
                        required: true,
                      })}
                      placeholder="Apellido Paterno"
                      autoComplete="last name"
                    />
                  </CInputGroup>
                  {errors['secondLastName'] && (
                    <CFormText component="span">
                      {errors['secondLastName']?.type === 'required' &&
                        'Este campo es obligatorio.'}
                    </CFormText>
                  )}
                  <CInputGroup className="mb-3">
                    <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText>
                    <CFormInput
                      {...register('secondLastName', {
                        required: true,
                      })}
                      placeholder="Apellido Materno"
                      autoComplete="second last name"
                    />
                  </CInputGroup>
                  {errors['email'] && (
                    <CFormText component="span">
                      {errors['email']?.type === 'required' &&
                        'Este campo es obligatorio.'}
                      {errors['email']?.type === 'pattern' &&
                        'formato de correo invalido.'}
                      {userTaken && 'Este correo ya esta registrado'}
                    </CFormText>
                  )}
                  <CInputGroup className="mb-3">
                    <CInputGroupText>@</CInputGroupText>
                    <CFormInput
                      {...register('email', {
                        pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/g,
                        required: true,
                      })}
                      placeholder="Email"
                      autoComplete="email"
                    />
                  </CInputGroup>
                  {errors['password'] && (
                    <CFormText component="span">
                      {errors['password']?.type === 'required' &&
                        'Este campo es obligatorio.'}
                      {errors['password']?.type === 'pattern' &&
                        'La contraseña debe tener entre 6 y 20 caracteres, al menos un numero, una mayuscula y una minuscula.'}
                    </CFormText>
                  )}
                  <CInputGroup className="mb-3">
                    <CInputGroupText>
                      <CIcon icon={cilLockLocked} />
                    </CInputGroupText>
                    <CFormInput
                      {...register('password', {
                        pattern:
                          /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/,
                        required: true,
                      })}
                      type="password"
                      placeholder="Contraseña"
                      autoComplete="new-password"
                    />
                  </CInputGroup>
                  {errors['password'] && (
                    <CFormText component="span">
                      {errors['password']?.type === 'required' &&
                        'Este campo es obligatorio. '}
                      {!confirmedPass && 'La contraseña no coincide.'}
                    </CFormText>
                  )}
                  <CInputGroup className="mb-4">
                    <CInputGroupText>
                      <CIcon icon={cilLockLocked} />
                    </CInputGroupText>
                    <CFormInput
                      {...register('passwordConfirmed', {
                        required: true,
                      })}
                      type="password"
                      placeholder="Confirma contraseña."
                      autoComplete="new-password"
                    />
                  </CInputGroup>
                  <div className="d-grid">
                    <CButton color="success" type="submit">
                      Crear Cuenta
                    </CButton>
                  </div>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
        <CRow>
          <h2>{response}</h2>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Register

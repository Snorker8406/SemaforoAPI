import React, { useState, useEffect } from 'react'
import PropTypes from 'prop-types'
import {
  CModal,
  CModalHeader,
  CModalBody,
  CButton,
  CModalFooter,
  CModalTitle,
  CForm,
  CRow,
  CFormLabel,
  CFormInput,
  CCol,
} from '@coreui/react'

const EditItem = (props) => {
  const { visible, setVisible, itemData, itemIdField, catalogFields, onClose } = props

  const [item, setItem] = useState({})

  useEffect(() => {
    setItem(itemData)
  }, [itemData])

  const toLower = (str) => {
    return str.charAt(0).toLowerCase() + str.slice(1)
  }

  const saveChanges = (e) => {
    fetch(props.APIurl + item[itemIdField], {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(item),
    })
      .then((res) => res.json())
      .then((result) => {
        setItem(result)
        setVisible(false)
      })
      .catch((err) => console.log('error'))
  }

  const onChangeValue = (e) => {
    setItem({ ...item, [e.target.name]: e.target.value })
  }

  const onCloseEdit = () => {
    setVisible(false)
    if (onClose) {
      onClose()
    }
  }

  return (
    <>
      {item && (
        <CModal size="xl" alignment="center" visible={visible} onClose={onCloseEdit}>
          <CModalHeader>
            <CModalTitle>Editing Item {item['name'] + ' ' + item[itemIdField]}</CModalTitle>
          </CModalHeader>
          <CModalBody>
            <CForm>
              {catalogFields.map((f) => (
                // eslint-disable-next-line react/jsx-key
                <CRow className="mb-3">
                  <CFormLabel
                    htmlFor={'input-' + toLower(f.name)}
                    className="col-sm-2 col-form-label"
                  >
                    {f.columnName}
                  </CFormLabel>
                  <CCol sm={10}>
                    <CFormInput
                      id={'input-' + f.name}
                      name={toLower(f.name)}
                      value={item[toLower(f.name)]}
                      onChange={(e) => onChangeValue(e)}
                    />
                  </CCol>
                </CRow>
              ))}
            </CForm>
          </CModalBody>
          <CModalFooter>
            <CButton color="secondary" onClick={() => setVisible(false)}>
              Close
            </CButton>
            <CButton color="primary" onClick={() => saveChanges()}>
              Guardar Cambios
            </CButton>
          </CModalFooter>
        </CModal>
      )}
    </>
  )
}
EditItem.propTypes = {
  visible: PropTypes.bool,
  setVisible: PropTypes.func,
  itemData: PropTypes.object,
  itemIdField: PropTypes.string,
  catalogFields: PropTypes.object,
  onClose: PropTypes.func,
  APIurl: PropTypes.string,
}
export default EditItem

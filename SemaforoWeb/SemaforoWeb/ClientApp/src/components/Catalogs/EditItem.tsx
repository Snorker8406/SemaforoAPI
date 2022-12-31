import React, { useState, useEffect } from 'react'
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
} from '@coreui/react-pro'

import { dataItem, dataColumn } from './types'

type propTypes = {
  visible: boolean
  setVisible: (visible: boolean) => void
  itemData: dataItem
  itemIdField: string
  catalogFields: dataColumn[]
  onClose: () => void
  APIurl: string
}

const EditItem = (props: propTypes) => {
  const { visible, setVisible, itemData, itemIdField, catalogFields, onClose } =
    props

  const [item, setItem] = useState<dataItem>({} as dataItem)

  type dataItemKey = keyof typeof item

  useEffect(() => {
    setItem(itemData)
  }, [itemData])

  const toLower = (str: string) => {
    return str.charAt(0).toLowerCase() + str.slice(1)
  }

  const saveChanges = () => {
    fetch(props.APIurl + item[itemIdField as dataItemKey], {
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

  const onChangeValue = (e: React.ChangeEvent<HTMLInputElement>) => {
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
        <CModal
          size="xl"
          alignment="center"
          visible={visible}
          onClose={onCloseEdit}
        >
          <CModalHeader>
            <CModalTitle>
              Editing Item{' '}
              {item['name'] + ' ' + item[itemIdField as dataItemKey]}
            </CModalTitle>
          </CModalHeader>
          <CModalBody>
            <CForm>
              {catalogFields.map((f, i) => (
                // eslint-disable-next-line react/jsx-key
                <CRow key={'field_' + i} className="mb-3">
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
                      value={item[toLower(f.name) as dataItemKey]}
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
export default EditItem

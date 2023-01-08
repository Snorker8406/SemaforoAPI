import React, { useState, useEffect, HTMLAttributes, forwardRef } from 'react'
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
} from '@coreui/react-pro'

import { dataItem, dataColumn } from './types'
import useFetch from '../Utils/useFetch'

export interface EditItemProps extends HTMLAttributes<HTMLDivElement> {
  visible: boolean
  setVisible: (visible: boolean) => void
  itemData: dataItem
  itemIdField: string
  catalogFields: dataColumn[]
  onClose: () => void
  APIurl: string
  isNewItem: boolean
  itemHasBeenUpdated: (updated: boolean) => void
}

export const EditItem = forwardRef<HTMLDivElement, EditItemProps>(
  (
    {
      visible,
      setVisible,
      itemData,
      itemIdField,
      catalogFields,
      onClose,
      APIurl,
      isNewItem,
      itemHasBeenUpdated,
    },
    ref,
  ) => {
    const [item, setItem] = useState<dataItem>({} as dataItem)
    const [formTitle, setFormTitle] = useState('')
    const [saveResponse, saveItem] = useFetch(APIurl, 'POST')

    type dataItemKey = keyof typeof item

    useEffect(() => {
      setItem(itemData)
    }, [itemData])

    useEffect(() => {
      if (isNewItem) {
        setFormTitle('Agregando Nuevo Registro')
      } else {
        setFormTitle(
          'Editando Registro ' +
            item[itemIdField as dataItemKey] +
            ' - ' +
            item['name'],
        )
      }
    }, [item])

    useEffect(() => {
      if (!saveResponse) return
      setItem(saveResponse)
      setVisible(false)
      itemHasBeenUpdated(true)
    }, [saveResponse])

    const toLower = (str: string) => {
      return str.charAt(0).toLowerCase() + str.slice(1)
    }

    const saveChanges = () => {
      saveItem(
        isNewItem ? '' : item[itemIdField as dataItemKey],
        item,
        isNewItem ? 'POST' : 'PUT',
      )
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
      item && (
        <CModal
          size="xl"
          alignment="center"
          visible={visible}
          onClose={onCloseEdit}
        >
          <CModalHeader>
            <CModalTitle>{formTitle}</CModalTitle>
          </CModalHeader>
          <CModalBody>
            <CForm>
              {catalogFields
                .filter((c) => !c.isPrimaryKey)
                .map((f, i) => (
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
      )
    )
  },
)

EditItem.propTypes = {
  visible: PropTypes.bool.isRequired,
  setVisible: PropTypes.func.isRequired,
  itemData: PropTypes.any.isRequired,
  itemIdField: PropTypes.string.isRequired,
  catalogFields: PropTypes.any.isRequired,
  onClose: PropTypes.func.isRequired,
  APIurl: PropTypes.string.isRequired,
  isNewItem: PropTypes.bool.isRequired,
  itemHasBeenUpdated: PropTypes.func.isRequired,
}

EditItem.displayName = 'EditItem'

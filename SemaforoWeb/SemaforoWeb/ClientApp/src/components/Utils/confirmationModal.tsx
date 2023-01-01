import React, { useState, useEffect, HTMLAttributes, forwardRef } from 'react'
import PropTypes from 'prop-types'
import {
  CModal,
  CModalHeader,
  CModalBody,
  CButton,
  CModalFooter,
  CModalTitle,
} from '@coreui/react-pro'

export interface ConfirmationModalProps extends HTMLAttributes<HTMLDivElement> {
  visible: boolean
  setVisible: (visible: boolean) => void
  userResponse: (response: boolean) => void
  message: string
  title: string
  onClose?: () => void
}

export const ConfirmationModal = forwardRef<
  HTMLDivElement,
  ConfirmationModalProps
>(({ visible, setVisible, userResponse, onClose, title, message }, ref) => {
  const onOk = () => {
    userResponse(true)
    setVisible(false)
  }

  const onCancel = () => {
    userResponse(false)
    setVisible(false)
  }

  return (
    <CModal visible={visible} onClose={onCancel}>
      <CModalHeader>
        <CModalTitle>{title}</CModalTitle>
      </CModalHeader>
      <CModalBody>{message}</CModalBody>
      <CModalFooter>
        <CButton color="secondary" onClick={onCancel}>
          Cancelar
        </CButton>
        <CButton color="primary" onClick={onOk}>
          Aceptar
        </CButton>
      </CModalFooter>
    </CModal>
  )
})
ConfirmationModal.propTypes = {
  visible: PropTypes.bool.isRequired,
  setVisible: PropTypes.func.isRequired,
  userResponse: PropTypes.func.isRequired,
  title: PropTypes.string.isRequired,
  message: PropTypes.string.isRequired,
  onClose: PropTypes.func,
}

ConfirmationModal.displayName = 'ConfirmationModal'

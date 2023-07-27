import React from 'react'
import { CFooter } from '@coreui/react-pro'

const AppFooter = () => {
  return (
    <CFooter>
      <div>
        <a
          href="https://elsemaforo.net"
          target="_blank"
          rel="noopener noreferrer"
        >
          Uniformes Zapotlán El Semáforo
        </a>
        <span className="ms-1">
          &copy; Nosotros los diseñamos, por eso los hacemos mejor
        </span>
      </div>
      <div className="ms-auto">
        <span className="me-1">Powered by</span>
        <a
          href="https://agrotecsa.com.mx"
          target="_blank"
          rel="noopener noreferrer"
        >
          AgroTECSA
        </a>
      </div>
    </CFooter>
  )
}

export default React.memo(AppFooter)

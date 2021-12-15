import React from 'react'
import { CFooter } from '@coreui/react'

const AppFooter = () => {
  return (
    <CFooter>
      <div>
        <a href="https://agrotecsa.com.mx/" target="_blank" rel="noopener noreferrer">
          Semaforo
        </a>
        <span className="ms-1">&copy; 2021 AgroTECSA Developers</span>
      </div>
      <div className="ms-auto">
        <span className="me-1">Powered by</span>
        <a href="https://agrotecsa.com.mx/" target="_blank" rel="noopener noreferrer">
          AgroTECSA
        </a>
      </div>
    </CFooter>
  )
}

export default React.memo(AppFooter)

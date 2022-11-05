import React, { useState, useEffect } from 'react'
import API from '../../../API'
import ItemsList from 'src/components/Catalogs/ItemsList'

const ListOfClients = () => {
  return <ItemsList APIurl={API.clients.APIurl} IdField={API.clients.IdField} />
}

export default ListOfClients

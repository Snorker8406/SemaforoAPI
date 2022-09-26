import React, { useState, useEffect } from 'react'
import ItemsList from 'src/components/Catalogs/ItemsList'

const fields = [
  {
    Header: 'ID',
    accessor: 'clientId', // accessor is the "key" in the data
  },
  {
    Header: 'Name',
    accessor: 'name', // accessor is the "key" in the data
  },
  {
    Header: 'Address',
    accessor: 'address',
  },
  {
    Header: 'User Id',
    accessor: 'userId',
  },
  {
    Header: 'Cellphone',
    accessor: 'cellphone',
  },
  {
    Header: 'Email',
    accessor: 'email',
  },
  {
    Header: 'Actions',
    accessor: 'actions',
  },
]
const ListOfClients = () => {
  return <ItemsList APIurl="/api/Client/" IdField="clientId" />
}

export default ListOfClients

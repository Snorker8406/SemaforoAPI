import React, { useState, useEffect } from 'react'
import { useTable, useSortBy } from 'react-table'
import {
  CTable,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CTableDataCell,
  CTableBody,
  CPagination,
  CPaginationItem,
} from '@coreui/react'
import { cilPencil, cilTrash } from '@coreui/icons'
import CIcon from '@coreui/icons-react'

const ListOfClients = () => {
  const [clients, setClients] = useState([])
  const [selectedClient, setSelectedClient] = useState([])
  useEffect(() => {
    fetch('/api/Client', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((result) => {
        setClients(result)
      })
      .catch((err) => console.log('error'))
  }, [])

  const data = React.useMemo(() => clients, [clients])

  const columns = React.useMemo(
    () => [
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
        Header: 'Account Days Limit',
        accessor: 'accountDaysLimit',
      },
      {
        Header: 'Account Amount Limit',
        accessor: 'accountAmountLimit',
      },
      {
        Header: 'Gender',
        accessor: 'gender',
      },
      {
        Header: 'Actions',
        accessor: 'actions',
      },
    ],
    [],
  )

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = useTable(
    {
      columns,
      data,
    },
    useSortBy,
  )

  const editClient = (clientId) => {
    fetch('/api/Client/' + clientId, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((result) => {
        setSelectedClient(result)
      })
      .catch((err) => console.log('error'))
  }

  return (
    <>
      <CTable {...getTableProps()} striped>
        <CTableHead>
          {headerGroups.map((headerGroup) => (
            <CTableRow {...headerGroup.getHeaderGroupProps()} key={'a'}>
              {headerGroup.headers.map((column) => (
                <CTableHeaderCell
                  {...column.getHeaderProps(column.getSortByToggleProps())}
                  key={'hd_' + column}
                >
                  {column.render('Header')}
                  <span>{column.isSorted ? (column.isSortedDesc ? ' 🔽' : ' 🔼') : ''}</span>
                </CTableHeaderCell>
              ))}
            </CTableRow>
          ))}
        </CTableHead>
        <CTableBody {...getTableBodyProps()}>
          {rows.map((row) => {
            prepareRow(row)
            return (
              <CTableRow {...row.getRowProps()} key={row.clientId}>
                {row.cells.map((cell) => {
                  if (cell.column.id === 'actions') {
                    return (
                      <CTableDataCell {...cell.getCellProps()} key={'d'}>
                        <CIcon
                          icon={cilPencil}
                          onClick={() => editClient(cell.row.values.clientId)}
                          id={'edit-icon-' + cell.row.values.clientId}
                        />
                        <CIcon icon={cilTrash} />
                      </CTableDataCell>
                    )
                  }
                  return (
                    <CTableDataCell {...cell.getCellProps()} key={'d'}>
                      {cell.render('Cell')}
                    </CTableDataCell>
                  )
                })}
              </CTableRow>
            )
          })}
        </CTableBody>
      </CTable>

      <CPagination>
        <CPaginationItem aria-label="Previous" disabled>
          <span aria-hidden="true">&laquo;</span>
        </CPaginationItem>
        <CPaginationItem active>1</CPaginationItem>
        <CPaginationItem>2</CPaginationItem>
        <CPaginationItem>3</CPaginationItem>
        <CPaginationItem aria-label="Next">
          <span aria-hidden="true">&raquo;</span>
        </CPaginationItem>
      </CPagination>
    </>
  )
}

export default ListOfClients

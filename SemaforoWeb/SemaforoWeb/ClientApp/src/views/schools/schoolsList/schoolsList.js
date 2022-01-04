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

const SchoolsList = () => {
  const [clients, setClients] = useState([])

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
        Header: 'Name',
        accessor: 'name', // accessor is the "key" in the data
      },
      {
        Header: 'Street',
        accessor: 'address',
      },
      {
        Header: 'Suburb',
        accesor: 'suburb',
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
        accesor: 'email',
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
  console.log('Clientes desde el State', clients)

  return (
    <>
      <CTable {...getTableProps()} striped>
        <CTableHead>
          {headerGroups.map((headerGroup) => (
            <CTableRow {...headerGroup.getHeaderGroupProps()} key={'accessor'}>
              {headerGroup.headers.map((column) => (
                <CTableHeaderCell
                  {...column.getHeaderProps(column.getSortByToggleProps())}
                  key={'accessor'}
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
              <CTableRow {...row.getRowProps()} key={'accessor'}>
                {row.cells.map((cell) => {
                  return (
                    <CTableDataCell {...cell.getCellProps()} key={'accessor'}>
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

export default SchoolsList
import React, { useState } from 'react'
import { useTable, useSortBy } from 'react-table'
import {
  CTable,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CTableDataCell,
  CTableBody,
} from '@coreui/react'

const ListOfClients = () => {
  const data = React.useMemo(
    () => [
      {
        col1: 'Hello',
        col2: 'World',
      },
      {
        col1: 'react-table',
        col2: 'rocks',
      },
      {
        col1: 'whatever',
        col2: 'you want',
        col3: 'Hola',
      },
    ],
    [],
  )

  const columns = React.useMemo(
    () => [
      {
        Header: 'Column 1',
        accessor: 'col1', // accessor is the "key" in the data
      },
      {
        Header: 'Column 2',
        accessor: 'col2',
      },
      {
        Header: 'Column 3',
        accessor: 'col3',
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

  return (
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
  )
}

export default ListOfClients

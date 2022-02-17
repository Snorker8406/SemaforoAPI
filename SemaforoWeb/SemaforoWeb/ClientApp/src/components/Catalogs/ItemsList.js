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

const ItemsList = (props) => {
  // eslint-disable-next-line react/prop-types
  const { APIurl, idField, fields } = props
  const [catalogItems, setCatalogItems] = useState([])
  const [selectedItem, setSelectedItem] = useState([])
  useEffect(() => {
    fetch(APIurl, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((result) => {
        setCatalogItems(result)
      })
      .catch((err) => console.log('error'))
  }, [])

  const data = React.useMemo(() => catalogItems, [catalogItems])

  const columns = React.useMemo(() => fields, [])

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = useTable(
    {
      columns,
      data,
    },
    useSortBy,
  )

  const editItem = (itemId) => {
    fetch(APIurl + itemId, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((result) => {
        setSelectedItem(result)
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
              <CTableRow {...row.getRowProps()} key={row[idField]}>
                {row.cells.map((cell) => {
                  if (cell.column.id === 'actions') {
                    return (
                      <CTableDataCell {...cell.getCellProps()} key={'d'}>
                        <CIcon
                          icon={cilPencil}
                          onClick={() => editItem(cell.row.values[idField])}
                          id={'edit-icon-' + cell.row.values[idField]}
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

export default ItemsList

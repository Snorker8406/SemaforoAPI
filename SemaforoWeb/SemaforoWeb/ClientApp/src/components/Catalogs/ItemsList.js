import React, { useState, useEffect } from 'react'
import PropTypes from 'prop-types'
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
import EditItem from './EditItem'
import Filter from './Filter'

const ItemsList = (props) => {
  const { APIurl, IdField } = props
  const [tableColumns, setTableColumns] = useState([])
  const [catalogFields, setCatalogFields] = useState([])
  const [catalogItems, setCatalogItems] = useState([])
  const [selectedItem, setSelectedItem] = useState()
  const [showEdit, setShowEdit] = useState(false)
  useEffect(() => {
    fetch(APIurl, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((result) => {
        setCatalogFields(result.columns)
        setTableColumns(handleColumns(result.columns))
        setCatalogItems(result.data)
      })
      .catch((err) => console.log('error'))
  }, [])

  const data = React.useMemo(() => catalogItems, [catalogItems])

  const columns = React.useMemo(() => tableColumns, [tableColumns])

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } = useTable(
    {
      columns,
      data,
    },
    useSortBy,
  )

  const handleColumns = (columns) => {
    var columnsList = columns
      .filter((c) => c.isColumn)
      .map((column) => {
        return {
          Header: column.columnName,
          accessor: column.name.charAt(0).toLowerCase() + column.name.slice(1),
        }
      })
    columnsList.push({
      Header: 'Actions',
      accessor: 'actions',
    })
    return columnsList
  }

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
        setShowEdit(true)
      })
      .catch((err) => console.log('error'))
  }

  const onCloseEdit = () => {
    fetch(APIurl, {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then((res) => res.json())
      .then((result) => {
        setCatalogFields(result.columns)
        setTableColumns(handleColumns(result.columns))
        setCatalogItems(result.data)
      })
      .catch((err) => console.log('error'))
  }

  return (
    <>
      {Filter()}
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
              <CTableRow {...row.getRowProps()} key={row[IdField]}>
                {row.cells.map((cell) => {
                  if (cell.column.id === 'actions') {
                    return (
                      <CTableDataCell {...cell.getCellProps()} key={'d'}>
                        <CIcon
                          icon={cilPencil}
                          onClick={() => editItem(cell.row.values[IdField])}
                          id={'edit-icon-' + cell.row.values[IdField]}
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
      <EditItem
        visible={showEdit}
        setVisible={setShowEdit}
        itemIdField={IdField}
        itemData={selectedItem}
        catalogFields={catalogFields.filter((f) => f.isInForm)}
        onClose={onCloseEdit}
        APIurl={APIurl}
      />
    </>
  )
}
ItemsList.propTypes = {
  APIurl: PropTypes.string,
  IdField: PropTypes.string,
}

export default ItemsList

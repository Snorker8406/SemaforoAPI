import React, { useState, useEffect, HTMLAttributes, forwardRef } from 'react'
import { cilPencil, cilTrash } from '@coreui/icons'
import CIcon from '@coreui/icons-react'
import { CSmartTable, CCardBody, CCollapse, CButton } from '@coreui/react-pro'
import { EditItem } from './EditItem'
import { Item } from '@coreui/react-pro/dist/components/table/CTable'
import { dataItem, dataColumn } from './types'
import PropTypes, { number } from 'prop-types'
import { ConfirmationModal } from '../Utils/confirmationModal'
export interface ItemsTableProps extends HTMLAttributes<HTMLDivElement> {
  APIurl: string
  idField: string
}

export const ItemsTable = forwardRef<HTMLDivElement, ItemsTableProps>(
  ({ APIurl, idField }, ref) => {
    const [catalogColumns, setCatalogColumns] = useState<dataColumn[]>([])
    const [details, setDetails] = useState<number[]>([])
    const [catalogItems, setCatalogItems] = useState([])
    const [selectedItem, setSelectedItem] = useState<dataItem>({} as dataItem)
    const [showEdit, setShowEdit] = useState(false)
    const [isNewItem, setIsNewItem] = useState(false)
    const [isItemUpdated, setIsItemUpdated] = useState(false)
    const [showConfirmDelete, setShowConfirmDelete] = useState(false)
    const [deleteConfirmation, setDeleteConfirmation] = useState(false)
    const [deleteConfirmMessage, setDeleteConfirmMessage] = useState('')

    useEffect(() => {
      fetch(APIurl, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      })
        .then((res) => res.json())
        .then((result) => {
          setCatalogColumns(result.columns)
          setCatalogItems(result.data)
        })
        .catch((err) => console.log('error'))
      // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const onCloseEdit = () => {
      if (!isItemUpdated) return
      fetch(APIurl, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      })
        .then((res) => res.json())
        .then((result) => {
          setCatalogColumns(result.columns)
          setCatalogItems(result.data)
          setIsItemUpdated(false)
        })
        .catch((err) => console.log('error'))
    }

    const handleColumns = (columns: dataColumn[]) => {
      const columnsList = columns.filter((c: dataColumn) => c.isColumn)
      columnsList.push({
        label: 'Acciones',
        key: 'actions',
        name: '',
        isPrimaryKey: false,
        type: '',
      })
      return columnsList
    }

    const renderDetails = (item: Item) => (
      <CCollapse visible={details.includes(item.providerId)}>
        <CCardBody>
          <h4>{item.name}</h4>
          <p className="text-muted">Direccion: {item.address}</p>
          <p>
            Pagina Web:{' '}
            <a
              target="_blank"
              href={'https://' + item.website}
              rel="noopener noreferrer"
            >
              {item.website}
            </a>
          </p>
        </CCardBody>
      </CCollapse>
    )

    const toggleDetails = (index: number) => {
      const position = details.indexOf(index)
      let newDetails = details.slice()
      if (position !== -1) {
        newDetails.splice(position, 1)
      } else {
        newDetails = [...details, index]
      }
      setDetails(newDetails)
    }

    const onAddNewItem = () => {
      const newItem = {} as any
      catalogColumns.forEach((f) => {
        if (!f.isPrimaryKey && f.isInForm) {
          newItem[f.key] = f.type.indexOf('Int32') > 0 ? 0 : ''
        }
      })
      setSelectedItem(newItem)
      setShowEdit(true)
      setIsNewItem(true)
    }

    const onEditItem = (itemId: number) => {
      fetch(APIurl + itemId, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      })
        .then((res) => res.json())
        .then((result) => {
          setSelectedItem(result)
          setIsNewItem(false)
          setShowEdit(true)
        })
        .catch((err) => console.log('error'))
    }

    const onDeleteItem = (itemIdField: string, registerName: string) => {
      const itemToDelete = { itemIdField } as any
      setSelectedItem(itemToDelete)
      setDeleteConfirmMessage(registerName)
      setShowConfirmDelete(true)
    }

    const deleteItem = (confirmed: boolean) => {
      if (confirmed) {
        fetch(APIurl + selectedItem.itemIdField, {
          method: 'DELETE',
          headers: {
            'Content-Type': 'application/json',
          },
        })
          .then((res) => res.json())
          .then((result) => {
            console.log(result)
            fetch(APIurl, {
              method: 'GET',
              headers: {
                'Content-Type': 'application/json',
              },
            })
              .then((res) => res.json())
              .then((result) => {
                setCatalogColumns(result.columns)
                setCatalogItems(result.data)
                setIsItemUpdated(false)
              })
              .catch((err) => console.log('error'))
          })
          .catch((err) => console.log('error'))
      }
    }

    const renderActions = (item: Item) => (
      <td>
        <CIcon icon={cilPencil} onClick={() => onEditItem(item.providerId)} />
        <CIcon
          icon={cilTrash}
          onClick={() => onDeleteItem(item.providerId, item.name)}
        />
      </td>
    )

    return (
      <>
        <div className="d-grid justify-content-md-end">
          <CButton
            color="success"
            shape="rounded-0"
            onClick={() => onAddNewItem()}
          >
            Crear Nuevo
          </CButton>
        </div>
        <CSmartTable
          activePage={3}
          cleaner
          clickableRows
          columns={handleColumns(catalogColumns)}
          columnSorter
          items={catalogItems}
          itemsPerPageSelect
          itemsPerPage={5}
          pagination
          scopedColumns={{
            actions: (item: Item) => renderActions(item),
            details: (item) => renderDetails(item),
          }}
          onRowClick={(item) => toggleDetails(item.providerId)}
          selectable
          sorterValue={{ column: 'name', state: 'asc' }}
          tableFilter
          tableHeadProps={{
            color: 'success',
          }}
          tableProps={{
            striped: true,
            hover: true,
            responsive: true,
          }}
        />
        <EditItem
          visible={showEdit}
          setVisible={setShowEdit}
          itemIdField={idField}
          itemData={selectedItem}
          catalogFields={catalogColumns.filter((f) => f.isInForm)}
          onClose={onCloseEdit}
          APIurl={APIurl}
          isNew={isNewItem}
          itemHasBeenUpdated={setIsItemUpdated}
        />
        <ConfirmationModal
          visible={showConfirmDelete}
          setVisible={setShowConfirmDelete}
          userResponse={deleteItem}
          title={'Confirma que desea borrar el registro?'}
          message={deleteConfirmMessage}
        />
      </>
    )
  },
)
ItemsTable.propTypes = {
  APIurl: PropTypes.string.isRequired,
  idField: PropTypes.string.isRequired,
}

ItemsTable.displayName = 'ItemsTable'

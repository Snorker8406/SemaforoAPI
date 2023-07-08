import React, {
  useState,
  useEffect,
  HTMLAttributes,
  forwardRef,
  Suspense,
  useContext,
} from 'react'
import { cilPencil, cilTrash } from '@coreui/icons'
import CIcon from '@coreui/icons-react'
import { CSmartTable, CCardBody, CCollapse, CButton } from '@coreui/react-pro'
import { EditItem } from './EditItem'
import { Item } from '@coreui/react-pro/dist/components/table/CTable'
import { dataItem, dataColumn } from '../../types'
import PropTypes from 'prop-types'
import { ConfirmationModal } from '../Utils/confirmationModal'
import useFetchCatalogs from '../Utils/useFetch'
import { SpinnerLoading } from '../Utils/spinnerLoading'
import { LoaderContext } from '../Utils/loaderContext'

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
    // const [isLoading, setIsLoading] = useState(true)
    const [deleteConfirmMessage, setDeleteConfirmMessage] = useState('')
    const [tableData, getTableData] = useFetchCatalogs(APIurl, 'GET')
    const [itemData, getItemData] = useFetchCatalogs(APIurl, 'GET')
    const [deletingResponse, deleteItem] = useFetchCatalogs(APIurl, 'DELETE')
    const { setShowLoader } = useContext(LoaderContext)

    useEffect(() => {
      setShowLoader(true)
      getTableData()
    }, [])

    useEffect(() => {
      if (!tableData) return
      setCatalogColumns(tableData.columns)
      setCatalogItems(tableData.data)
      setIsItemUpdated(false)
    }, [tableData])

    useEffect(() => {
      if (!itemData) return
      setSelectedItem(itemData)
      if (itemData[idField] > 0) {
        setIsNewItem(false)
      }
      setShowEdit(true)
    }, [itemData])

    useEffect(() => {
      if (!deletingResponse) return
      getTableData()
    }, [deletingResponse])

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

    const handleDeleteItem = (confirmed: boolean) => {
      if (confirmed) {
        deleteItem(selectedItem.itemIdField)
      }
    }

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
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const newItem = {} as any
      let fillOptions = false
      catalogColumns.forEach((f) => {
        if (!f.isPrimaryKey && f.isInForm) {
          newItem[f.key] = f.type.indexOf('Int32') > 0 ? 0 : ''
          if (f.selectKey) fillOptions = true
        }
      })
      setSelectedItem(newItem)
      setShowEdit(true)
      setIsNewItem(true)
      if (fillOptions) getItemData(-1)
    }

    const onEditItem = (itemId: number) => {
      getItemData(itemId)
    }

    const onDeleteItem = (itemIdField: string, registerName: string) => {
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const itemToDelete = { itemIdField } as any
      setSelectedItem(itemToDelete)
      setDeleteConfirmMessage(registerName)
      setShowConfirmDelete(true)
    }

    const onCloseEdit = () => {
      if (!isItemUpdated) return
      getTableData()
    }

    const renderDetails = (item: Item) => (
      <CCollapse visible={details.includes(item[idField])}>
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

    const renderActions = (item: Item) => (
      <td>
        <CIcon icon={cilPencil} onClick={() => onEditItem(item[idField])} />
        <CIcon
          icon={cilTrash}
          onClick={() => onDeleteItem(item[idField], item.name)}
        />
      </td>
    )

    // if (isLoading) return <SpinnerLoading />
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
          onRowClick={(item) => toggleDetails(item[idField])}
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
          // loading={isLoading}
        />
        <EditItem
          visible={showEdit}
          setVisible={setShowEdit}
          itemIdField={idField}
          itemData={selectedItem}
          catalogFields={catalogColumns.filter((f) => f.isInForm)}
          onClose={onCloseEdit}
          APIurl={APIurl}
          isNewItem={isNewItem}
          itemHasBeenUpdated={setIsItemUpdated}
        />
        <ConfirmationModal
          visible={showConfirmDelete}
          setVisible={setShowConfirmDelete}
          userResponse={handleDeleteItem}
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

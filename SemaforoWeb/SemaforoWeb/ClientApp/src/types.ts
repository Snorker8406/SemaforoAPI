export type dataItem = {
  itemIdField: string | undefined
  name: string
  value: string
}
export type dataColumn = {
  isColumn?: boolean
  isInForm?: boolean
  label: string
  key: string
  name: string
  columnName?: string
  isPrimaryKey: boolean
  type: string
}
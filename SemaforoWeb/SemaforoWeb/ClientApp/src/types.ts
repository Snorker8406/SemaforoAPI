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
  isPrimaryKey: boolean
  type: string
  required?: boolean
  validationPattern?: string
  size?: number
  dropdownEntity?: string
  dropdownKey?: string
  dropdownOption?: string
}

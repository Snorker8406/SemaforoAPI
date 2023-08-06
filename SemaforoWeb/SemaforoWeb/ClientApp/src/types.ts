export type dataItem = {
  itemIdField: string | undefined
  name: string
  // value: string
  files?: fileDTO[] | any
  images?: fileDTO[] | any
  profileImage: string
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
  rows?: number
  selectEntity?: string
  selectKey?: string
  selectOption?: string
}

export type fileDTO = {
  fileId: number
  fileName: string
  fieldType: string
  contentType: string
  archive: string
}

export type LoaderType = {
  showLoader: boolean
  setShowLoader: (show: boolean) => void
}

export type dateField = {
  field: string
  datetime: Date | null
}

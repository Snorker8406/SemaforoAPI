/* eslint-disable @typescript-eslint/no-empty-function */
import { createContext } from 'react'

export const LoaderContext = createContext({
  showLoader: false,
  setShowLoader: (show: boolean) => {},
  type: '',
  setType: (type: string) => {},
})

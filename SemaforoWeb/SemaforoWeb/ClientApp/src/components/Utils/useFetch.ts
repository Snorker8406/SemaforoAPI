import { useContext, useState } from 'react'
import { LoaderContext } from './loaderContext'

const useFetchCatalogs = (APIurl: string, httpRequest?: string) => {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [data, setData] = useState<any>(null)
  const { setShowLoader } = useContext(LoaderContext)

  const triggerFetch = async (
    item?: string,
    payload?: FormData,
    tHttpRequest?: string,
    tAPIurl?: string,
  ) => {
    try {
      setShowLoader(true)
      const http = tHttpRequest ? tHttpRequest : httpRequest
      let url: string = tAPIurl ? tAPIurl : APIurl
      if (item && (http === 'GET' || http === 'PUT' || http === 'DELETE')) {
        url += item
      }

      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const options: any = {
        method: http,
        headers: { 'Content-Type': 'application/json' },
        credentials: 'include',
      }
      if (http === 'POST' || (item && http === 'PUT')) {
        options.body = payload ? payload : ''
        options.headers = { enctype: 'multipart/form-data' }
      }

      const fetchData = async () => {
        const data = await fetch(url, options)
        const json = await data.json()
        setData(json)
        setShowLoader(false)
      }
      fetchData()
    } catch (error) {
      setShowLoader(false)
      console.log(error)
    }
  }

  return [data, triggerFetch]
}
export const useFetch = (APIurl: string, httpRequest?: string) => {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [data, setData] = useState<any>(null)
  const { setShowLoader } = useContext(LoaderContext)

  const triggerFetch = async (
    item?: string,
    payload?: unknown,
    tHttpRequest?: string,
    tAPIurl?: string,
  ) => {
    try {
      setShowLoader(true)
      const http = tHttpRequest ? tHttpRequest : httpRequest
      let url: string = tAPIurl ? tAPIurl : APIurl
      if (item && (http === 'GET' || http === 'PUT' || http === 'DELETE')) {
        url += item
      }

      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const options: any = {
        method: http,
        headers: { 'Content-Type': 'application/json' },
        credentials: 'include',
      }
      if (http === 'POST' || (item && http === 'PUT')) {
        options.body = JSON.stringify(payload ? payload : '')
      }

      const fetchData = async () => {
        const data = await fetch(url, options)
        const json = await data.json()
        setData(json)
        setShowLoader(false)
      }
      fetchData()
    } catch (error) {
      setShowLoader(false)
      console.log(error)
    }
  }

  return [data, triggerFetch]
}

export default useFetchCatalogs

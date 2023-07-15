import { useContext, useState } from 'react'
import { LoaderContext } from '../shared/loaderContext'

export const useFetch = (APIurl: string, httpRequest?: string) => {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const [data, setData] = useState<any>(null)
  const { setShowLoader } = useContext(LoaderContext)

  const triggerFetch = async (
    item?: string,
    payload?: FormData | unknown,
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
        if (url.indexOf('Catalog') > -1) {
          options.headers = { enctype: 'multipart/form-data' }
          options.body = payload ? payload : ''
        } else {
          options.body = JSON.stringify(payload ? payload : '')
        }
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

export default useFetch

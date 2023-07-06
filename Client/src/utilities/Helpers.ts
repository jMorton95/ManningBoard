
export const getInitials = (fullName: string): string => fullName.split(' ').map(x => x[0]).join('').toUpperCase();

export const binaryStringToImgSrc = (binaryString: string): string => {
  return `data:image/jpeg;base64, ${binaryString}`
}
